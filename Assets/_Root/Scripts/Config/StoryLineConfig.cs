using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StoryLineConfig", menuName = "Game/StoryLineConfig")]
public class StoryLineConfig : ScriptableObject
{
    public List<StoryLineData> StoryLineDatas;
}

[Serializable]
public class StoryLineData
{
    public IDStoryLine idStoryLine;
    public List<StoryLineText> StoryLineTexts;
}
[Serializable]
public class StoryLineText
{
    public int lineNumber;
    public IDCharacter Character;
    public string txt;
    public int nextLineNumber;
}