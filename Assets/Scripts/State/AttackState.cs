using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterController
{
    public class AttackState : CharaStateBase
    {
        public override void OnEnter(CharacterController chara, CharaStateBase state)
        {
            chara._state = CharaState.Attack;
            Debug.Log(chara._state);
            chara.EnemyControllers[0].Damage(chara.ThisPalam.Power);
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