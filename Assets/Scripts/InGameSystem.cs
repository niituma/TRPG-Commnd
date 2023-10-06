using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSystem : MonoBehaviour
{
    [SerializeField] OpenUIContoller _openUIContoller;

    [SerializeField] CanvasGroup _selectButtons;
    [SerializeField]
    Button _attackButton;
    [SerializeField]
    Button _actionButton;
    [SerializeField]
    JudgeTextContoller _charaJudgeBar;
    [SerializeField]
    JudgeTextContoller _enemyJudgeBar;

    CharacterController _currentChara;

    public CanvasGroup SelectButtons { get => _selectButtons; private set => _selectButtons = value; }

    private void Start()
    {
        _charaJudgeBar.Canvas.alpha = 0;
        _enemyJudgeBar.Canvas.alpha = 0;
    }

    public void RateJudge(float a, float b, float time)
    {
        _charaJudgeBar.RateJudgeView(a, b, time);
    }
    public void SelectChara(CharacterController chara)
    {
        _currentChara = chara;
        SetCharaActiveButton(_currentChara);
    }

    void SetCharaActiveButton(CharacterController chara)
    {
        if (chara == null)
        {
            _attackButton.onClick.RemoveAllListeners();
            return;
        }

        _attackButton.onClick.AddListener(() =>
        {
            _charaJudgeBar.Canvas.alpha = 1;
            chara.ChangeState(CharaState.Attack);
            ResetSelectButton();
        });

        _actionButton.onClick.AddListener(() =>
        {
            chara.ChangeState(CharaState.Action);
            _selectButtons.alpha = 0;
            _selectButtons.interactable = false;
            ResetSelectButton();
        });
    }

    /// <summary>
    /// セレクトボタンを非表示、押したときの処理も削除
    /// </summary>
    private void ResetSelectButton()
    {
        _selectButtons.alpha = 0;
        _selectButtons.interactable = false;
        _attackButton.onClick.RemoveAllListeners();
        _actionButton.onClick.RemoveAllListeners();
    }

    IEnumerator StartEvent()
    {

        yield return null;
    }

    IEnumerator OnNextEvent()
    {


        yield return null;
    }
}
