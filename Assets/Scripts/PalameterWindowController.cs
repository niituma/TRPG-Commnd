using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PalameterWindowController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _name;
    [SerializeField]
    TextMeshProUGUI _hp;
    [SerializeField]
    TextMeshProUGUI _speed;
    [SerializeField]
    TextMeshProUGUI _power;
    [SerializeField]
    CharacterController _chara;
    // Start is called before the first frame update
    void Start()
    {
        SetPalamText();
    }

    private void SetPalamText()
    {
        _name.text = $"NAME : {_chara.ThisPalam.name}";
        _hp.text = $"HP : {_chara.ThisPalam.HP}";
        _speed.text = $"SPEED : {_chara.ThisPalam.Speed}";
        _power.text = $"POWER : {_chara.ThisPalam.Power}";
    }
}
