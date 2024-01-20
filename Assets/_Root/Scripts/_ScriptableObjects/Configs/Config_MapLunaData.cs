using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Config_MapLunaData", menuName = "Game/Config_MapLunaData")]
public class Config_MapLunaData : ScriptableObject
{
    public List<PrefabData> ListFruitImages;
    public List<PrefabData> ListNotFruitImages;
}

[Serializable]
public class PrefabData
{
    public Sprite data_image;
    public int data_score;
}