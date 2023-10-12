using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSystem : MonoBehaviour
{
    [SerializeField] OpenUIContoller _openUIContoller;
    [SerializeField] ButtleCommndCtrl _commnd;
    [SerializeField]
    List<ExplorerController> _explorers;
    [SerializeField]
    List<EnemyController> _enemise;

    [SerializeField] CanvasGroup _selectButtons;
    [SerializeField] Button _attackButton;
    [SerializeField] Button _actionButton;

    ExplorerController _currentExplorer;
    Coroutine _buttleCorotine;

    public CanvasGroup SelectButtons { get => _selectButtons; private set => _selectButtons = value; }

    private void Start()
    {
        _buttleCorotine = StartCoroutine(RunButtleEventAsync());
    }
    public void SelectChara(ExplorerController chara)
    {
        _currentExplorer = chara;
        SetCharaActiveButton(_currentExplorer);
    }

    void SetCharaActiveButton(CharacterController chara)
    {
        ResetSelectButton();

        if (chara == null)
        {
            _attackButton.onClick.RemoveAllListeners();
            return;
        }

        _attackButton.onClick.AddListener(() =>
        {
            chara.ChangeState(CharaState.Attack);
            _selectButtons.interactable = false;
        });

        _actionButton.onClick.AddListener(() =>
        {
            chara.ChangeState(CharaState.Action);
            _selectButtons.interactable = false;
        });
    }

    /// <summary>
    /// �Z���N�g�{�^�����\���A�������Ƃ��̏������폜
    /// </summary>
    private void ResetSelectButton()
    {
        _attackButton.onClick.RemoveAllListeners();
        _actionButton.onClick.RemoveAllListeners();
    }

    IEnumerator RunButtleEventAsync()
    {
        while (true)
        {
            //�؂�ւ����o
            yield return new WaitForSecondsRealtime(2f);

            yield return EnemyAttackEvent();
            if (CheckButtleFinish()) { Debug.Log("�퓬�I��"); break; }

            //�؂�ւ����o
            yield return new WaitForSecondsRealtime(2f);

            yield return AttackEvent();
            if (CheckButtleFinish()) { Debug.Log("�퓬�I��"); break; }
        }
        yield return null;
    }

    bool CheckButtleFinish()
    {
        bool isfnish = true;

        foreach (CharacterController ex in _explorers)
        {
            if (ex.State != CharaState.Dead) { isfnish = false; break; }
        }

        foreach (CharacterController e in _enemise)
        {
            if (e.State != CharaState.Dead) { isfnish = false; break; }
            isfnish = true;
        }

        if (isfnish)
        {
            StopCoroutine(_buttleCorotine);
            _buttleCorotine = null;
        }

        return isfnish;
    }

    IEnumerator EnemyAttackEvent()
    {
        foreach (var e in _enemise)
        {
            if (e.State == CharaState.Dead) { continue; }
            e.ChangeState(CharaState.Attack);
            yield return WaitCharaState(e, CharaState.Wait);
            yield return new WaitForSecondsRealtime(1.5f);//�A�j���[�V�����ŃX�e�[�g�ύX����Ώ�������
            if (CheckButtleFinish()) { break; }
        }

        yield return null;
    }

    IEnumerator AttackEvent()
    {
        SelectButtons.interactable = true;
        SelectButtons.alpha = 1;
        foreach (var c in _explorers)
        {
            if (c.State is not CharaState.Dead and not CharaState.Wait) { Debug.LogError($"�I�𒆂�{c.name}���ҋ@��Ԃł͂���܂���B"); }
            if (c.State == CharaState.Dead) { continue; }
            _selectButtons.interactable = true;
            SelectChara(c);
            yield return WaitCharaState(c, CharaState.Wait);
            if (CheckButtleFinish()) { break; }
            yield return new WaitForSecondsRealtime(1f);//�A�j���[�V�����ŃX�e�[�g�ύX����Ώ�������
        }

        SelectButtons.interactable = false;
        SelectButtons.alpha = 0;

        yield return new WaitForSecondsRealtime(2f);

        yield return null;
    }

    /// <summary>
    /// �I�𒆂̃L����������̃X�e�[�g����O���܂őҋ@����
    /// </summary>
    /// <param name="c"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    private IEnumerator WaitCharaState(CharacterController c, CharaState state)
    {
        while (c.State == state) { yield return null; }
    }
}

public enum StageState
{
    Explore,
    Battle
}
