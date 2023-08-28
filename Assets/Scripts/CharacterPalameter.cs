using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateParam")]
public class CharacterPalameter : ScriptableObject
{
    public string Name = "";

    public int HP = 100;
    public int Speed = 20;
    public int Power = 20;
}
