using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemConfig", menuName = "Game/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    public List<ItemData> ItemDatas;
}

[Serializable]
public class ItemData
{
    public string ID;
    public GameObject Item;
    public Sprite Icon;
}