using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public partial class CharacterController : MonoBehaviour
{
    [SerializeField]
    CharacterPalameter _thisPalam;
    [SerializeField]
    InGameSystem _gameSystem;

    static readonly ActionState _actionState = new ActionState();
    static readonly AttackState _attackState = new AttackState();

    public CharaState State;

    [SerializeField]
    CharacterController _currentTarget;
    CharaStateBase _currentState;
    public HPController ThisHP { get; private set; }

    public CharacterPalameter ThisPalam { get => _thisPalam; }

    private void Awake()
    {
        ThisHP = GetComponent<HPController>();
        ThisHP.OnDead += () => { ChangeState(CharaState.Dead); };
        _currentState = _actionState;
    }
    public void RateJudge(float rate, float value, float time)
    {
        _gameSystem.RateJudge(rate, value, time, this);
    }
    void ChangeState(CharaStateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        nextState.OnEnter(this, _currentState);
        _currentState = nextState;
    }
    public void ChangeState(CharaState nextState)
    {
        switch (nextState)
        {
            case CharaState.Action:
                ChangeState(_actionState);
                break;
            case CharaState.Attack:
                ChangeState(_attackState);
                break;
            case CharaState.Wait:
                State = CharaState.Wait;
                break;
            case CharaState.Dead:
                State = CharaState.Dead;
                break;
            default:
                break;
        }
    }
}

public enum CharaState
{
    Wait,
    AttackStandby,
    Attack,
    Action,

    Dead
}
