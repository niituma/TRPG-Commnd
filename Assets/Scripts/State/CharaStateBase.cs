using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharaStateBase
{
    /// <summary>
    /// ����state�ɓ������珈������
    /// </summary>
    public virtual void OnEnter(CharacterController chara, CharaStateBase state) { }
    /// <summary>
    /// ��Ԃ�����state�̎��ɏ�������
    /// </summary>
    public virtual void OnUpdate(CharacterController chara, CharaStateBase state) { }
    /// <summary>
    /// ����state�𔲂����珈������
    /// </summary>
    public virtual void OnExit(CharacterController chara, CharaStateBase state) { }
}
