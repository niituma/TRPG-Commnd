using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class CharacterController : MonoBehaviour
{
    [SerializeField]
    CharacterPalameter _thisPalam;

    static readonly ActionState _actionState = new ActionState();
    static readonly AttackState _attackState = new AttackState();

    CharaStateBase _currentState;
    Button _actionButton;

    public CharacterPalameter ThisPalam { get => _thisPalam; }

    private void Awake()
    {
        _actionButton = GetComponent<Button>();

        _currentState = _actionState;

        _actionButton.onClick.AddListener(() =>
        {
            CharaStateBase state = _currentState == _actionState ? _attackState : _actionState;
            ChangeState(state);
        });
    }

    public void ChangeState(CharaStateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        nextState.OnEnter(this, _currentState);
        _currentState = nextState;
    }
}
