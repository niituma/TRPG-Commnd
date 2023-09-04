using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharaStateBase
{
    /// <summary>
    /// このstateに入ったら処理する
    /// </summary>
    public virtual void OnEnter(CharaStateBase state) { }
    /// <summary>
    /// 状態がこのstateの時に処理する
    /// </summary>
    public virtual void OnUpdate(CharaStateBase state) { }
    /// <summary>
    /// このstateを抜けたら処理する
    /// </summary>
    public virtual void OnExit(CharaStateBase state) { }
}
