using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterController
{
    public class ActionState : CharaStateBase
    {
        public override void OnEnter(CharacterController chara, CharaStateBase state)
        {
            chara._state = CharaState.Action;
            Debug.Log(chara._state);
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