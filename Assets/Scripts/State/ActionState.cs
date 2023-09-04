using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : CharaStateBase
{
    public override void OnEnter(CharacterController chara, CharaStateBase state)
    {
        Debug.Log("action");
    }
    public override void OnUpdate(CharacterController chara, CharaStateBase state)
    {

    }
    public override void OnExit(CharacterController chara, CharaStateBase state)
    {
        Debug.Log("action close");
    }
}
