using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerController : CharacterController
{
    [SerializeField]
    HPController[] enemyControllers;

    public HPController[] EnemyControllers { get => enemyControllers; }
}
