using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CharaStateBase
{
    public override void OnEnter(CharacterController chara, CharaStateBase state)
    {
        Debug.Log("attack");
        chara.EnemyControllers[0].Damage(10);
    }
    public override void OnUpdate(CharacterController chara, CharaStateBase state)
    {

    }
    public override void OnExit(CharacterController chara, CharaStateBase state)
    {
        Debug.Log("attack close");
    }
}
