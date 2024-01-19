using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Game/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    public List<CharacterData> CharacterDatas;
}

[Serializable]
public class CharacterData
{
    public IDCharacter idCharacter;
    public GameObject Character;
    public Sprite Icon;
}