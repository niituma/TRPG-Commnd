using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterController
{
    public class ActionState : CharaStateBase
    {
        public override void OnEnter(CharacterController chara, CharaStateBase state)
        {
            chara.State = CharaState.Action;
            Debug.Log(chara.State);

            DOTween.Sequence()
            .AppendInterval(0.5f)
            .AppendCallback(() =>
            {
                chara.ChangeState(CharaState.Wait);
            });
        }
        public override void OnUpdate(CharacterController chara, CharaStateBase state)
        {

        }
        public override void OnExit(CharacterController chara, CharaStateBase state)
        {
            Debug.Log("action close");
        }
    }
}