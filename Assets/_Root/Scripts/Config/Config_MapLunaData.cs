using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Config_MapLunaData", menuName = "Game/Config_MapLunaData")]
public class Config_MapLunaData : ScriptableObject
{
    public int currentScore;
    public List<Sprite> ListFruitImages;
    public List<Sprite> ListNotFruitImages;
}