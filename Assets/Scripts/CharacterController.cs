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
    [SerializeField]
    CanvasGroup _selectButtons;
    [SerializeField]
    InGameSystem _gameSystem;

    static readonly ActionState _actionState = new ActionState();
    static readonly AttackState _attackState = new AttackState();

    public CharaState _state;

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
            var a = _selectButtons.alpha == 0 ? 1 : 0;
            var active = a == 0 ? false : true;
            _selectButtons.interactable = active;
            _selectButtons.alpha = a;
            _gameSystem.SelectChara(this);
        });
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
                break;
            default: 
                break;
        }
    }
}

public enum CharaState
{
    Wait,
    Attack,
    Action,

    Dead
}
