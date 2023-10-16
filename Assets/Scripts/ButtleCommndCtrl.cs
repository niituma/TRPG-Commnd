using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;

public class ButtleCommndCtrl : MonoBehaviour
{
    [SerializeField] CanvasGroup _selectButtons;
    [SerializeField] Button _attackButton;
    [SerializeField] Button _actionButton;

    public void SetCharaActiveButton(CharacterController chara)
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

    public void ViewCommndButtonActive(bool active)
    {
        if (active)
        {
            _selectButtons.interactable = true;
            _selectButtons.alpha = 1;
        }
        else
        {
            _selectButtons.interactable = false;
            _selectButtons.alpha = 0;
        }
    }

    /// <summary>
    /// セレクトボタンを非表示、押したときの処理も削除
    /// </summary>
    public void ResetSelectButton()
    {
        _attackButton.onClick.RemoveAllListeners();
        _actionButton.onClick.RemoveAllListeners();
    }
}
