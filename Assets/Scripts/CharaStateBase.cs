using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharaStateBase
{
    /// <summary>
    /// ‚±‚Ìstate‚É“ü‚Á‚½‚çˆ—‚·‚é
    /// </summary>
    public virtual void OnEnter(CharaStateBase state) { }
    /// <summary>
    /// ó‘Ô‚ª‚±‚Ìstate‚Ì‚Éˆ—‚·‚é
    /// </summary>
    public virtual void OnUpdate(CharaStateBase state) { }
    /// <summary>
    /// ‚±‚Ìstate‚ğ”²‚¯‚½‚çˆ—‚·‚é
    /// </summary>
    public virtual void OnExit(CharaStateBase state) { }
}
