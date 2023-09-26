using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSystem : MonoBehaviour
{
    [SerializeField]
    Button _attackButton;
    [SerializeField]
    Button _actionButton;

    CharacterController _currentChara;

    public void SelectChara(CharacterController chara)
    {
        _currentChara = chara;
        SetCharaActiveButton(_currentChara);
    }

    void SetCharaActiveButton(CharacterController chara)
    {
        _attackButton.onClick.AddListener(() => chara.ChangeState(CharaState.Attack));

        _actionButton.onClick.AddListener(() => chara.ChangeState(CharaState.Action));
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
