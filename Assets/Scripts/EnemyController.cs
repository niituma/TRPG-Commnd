using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyController : MonoBehaviour
{
    [SerializeField]
    CharacterPalameter _thisPalam;

    public CharacterPalameter ThisPalam { get => _thisPalam; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
