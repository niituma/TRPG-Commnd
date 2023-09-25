using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public partial class CharacterController : MonoBehaviour
{
    [SerializeField]
    HPController[] enemyControllers;

    [SerializeField]
    CharacterPalameter _thisPalam;

    static readonly ActionState _actionState = new ActionState();
    static readonly AttackState _attackState = new AttackState();

    CharaStateBase _currentState;
    HPController _thisHP;
    Button _actionButton;

    public CharacterPalameter ThisPalam { get => _thisPalam; }
    public HPController[] EnemyControllers { get => enemyControllers; }

    private void Awake()
    {
        _actionButton = GetComponent<Button>();
        _thisHP = GetComponent<HPController>();

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
