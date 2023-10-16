using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSystem : MonoBehaviour
{
    [SerializeField] ButtleCommndCtrl _commnd;
    [SerializeField] ViewAttackUI _attackUI;
    [SerializeField] List<ExplorerController> _explorers;
    [SerializeField] List<EnemyController> _enemise;

    ExplorerController _currentExplorer;
    Coroutine _buttleCorotine;

    private void Start()
    {
        _buttleCorotine = StartCoroutine(RunButtleEventAsync());
    }
    public void SelectChara(ExplorerController chara)
    {
        _currentExplorer = chara;
        _commnd.SetCharaActiveButton(_currentExplorer);
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
        bool deadPlayer = true;
        bool deadEnemy = true;

        foreach (CharacterController ex in _explorers)
        {
            if (ex.State != CharaState.Dead) { deadPlayer = false; break; }
        }

        foreach (CharacterController e in _enemise)
        {
            if (e.State != CharaState.Dead) { deadEnemy = false; break; }
        }


        return deadPlayer || deadEnemy;
    }

    IEnumerator EnemyAttackEvent()
    {
        foreach (var e in _enemise)
        {
            if (e.State == CharaState.Dead) { continue; }
            e.ChangeState(CharaState.Attack);
            _attackUI.RateJudge(e._successRate, e._currentRateValue, 0.5f, e);
            yield return WaitCharaState(e, CharaState.Wait);
            yield return new WaitForSecondsRealtime(1.5f);//�A�j���[�V�����ŃX�e�[�g�ύX����Ώ�������
            if (_enemise[_enemise.Count - 1] == e) { _attackUI.ViewHiddenJudgeBar(e); }
            if (CheckButtleFinish()) { _attackUI.ViewHiddenJudgeBar(e); break; }
        }
        yield return null;
    }

    IEnumerator AttackEvent()
    {
        foreach (var c in _explorers)
        {
            if (c.State is not CharaState.Dead and not CharaState.Wait) { Debug.LogError($"�I�𒆂�{c.name}���ҋ@��Ԃł͂���܂���B"); }
            if (c.State == CharaState.Dead) { continue; }
            _commnd.ViewCommndButtonActive(true);
            SelectChara(c);
            yield return WaitCharaState(c, CharaState.Wait);
            if (c.State is CharaState.Attack) { _attackUI.RateJudge(c._successRate, c._currentRateValue, 0.5f, c); }
            yield return new WaitForSecondsRealtime(1f);//�A�j���[�V�����ŃX�e�[�g�ύX����Ώ�������
            if (_explorers[_explorers.Count - 1] == c) { _attackUI.ViewHiddenJudgeBar(c); }
            if (CheckButtleFinish()) { _attackUI.ViewHiddenJudgeBar(c); break; }
        }

        _commnd.ViewCommndButtonActive(false);

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
