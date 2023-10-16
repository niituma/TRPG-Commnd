using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterController
{
    public int _successRate { get; private set; } = 60; //パラメーターから所得するかもしれないから仮で書いた
    public int _currentRateValue { get; private set; } = 0;
    public class AttackState : CharaStateBase
    {
        
        float _viewTime = 0.5f;

        public override void OnEnter(CharacterController chara, CharaStateBase state)
        {
            chara.State = CharaState.Attack;
            Debug.Log(chara.State);

            chara._currentRateValue = Random.Range(1, 100);

            DOTween.Sequence()
            .AppendInterval(_viewTime)
            .AppendCallback(() =>
            {
                if (chara._successRate >= chara._currentRateValue) { chara._currentTarget.ThisHP.Damage(chara.ThisPalam.Power); }
                else { Debug.Log("MISS"); }

                chara.ChangeState(CharaState.Wait);
            });
        }
        public override void OnUpdate(CharacterController chara, CharaStateBase state)
        {

        }
        public override void OnExit(CharacterController chara, CharaStateBase state)
        {
            Debug.Log("attack close");
        }
    }

}