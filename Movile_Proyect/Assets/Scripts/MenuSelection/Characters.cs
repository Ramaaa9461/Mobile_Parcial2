using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class Characters : ScriptableObject
{
    public GameObject character_prefab;
    public Sprite image;
    public int value;
    public string characterName;
    public bool isUnlocked;
}
