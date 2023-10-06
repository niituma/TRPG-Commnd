using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterController
{
    public class AttackState : CharaStateBase
    {
        int _successRate = 60;
        float _viewTime = 0.5f;

        public override void OnEnter(CharacterController chara, CharaStateBase state)
        {
            chara.State = CharaState.Attack;
            Debug.Log(chara.State);

            var value = Random.Range(1, 100);
            chara.RateJudge(_successRate, value, _viewTime);

            DOTween.Sequence()
            .AppendInterval(_viewTime)
            .AppendCallback(() =>
            {
                if (_successRate >= value) { chara._currentTarget.ThisHP.Damage(chara.ThisPalam.Power); }
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