using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TextConfig", menuName = "Game/TextConfig")]
public class TextConfig : ScriptableObject
{
    public List<TextData> TextDatas;
}

[Serializable]
public class TextData
{
    public IDText idText;
    public List<TextDataDetails> TextDetails;
}
[Serializable]
public class TextDataDetails
{
    public int stt;
    public GameObject Item;
    public string txt;
    public int sttNext;
}