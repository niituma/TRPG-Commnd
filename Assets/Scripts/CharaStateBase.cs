using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharaStateBase
{
    /// <summary>
    /// ����state�ɓ������珈������
    /// </summary>
    public virtual void OnEnter(CharaStateBase state) { }
    /// <summary>
    /// ��Ԃ�����state�̎��ɏ�������
    /// </summary>
    public virtual void OnUpdate(CharaStateBase state) { }
    /// <summary>
    /// ����state�𔲂����珈������
    /// </summary>
    public virtual void OnExit(CharaStateBase state) { }
}
