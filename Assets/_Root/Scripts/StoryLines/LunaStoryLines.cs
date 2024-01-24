using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LunaStoryLines : StoryLine
{
    private void Awake()
    {
        idStoryLine = IDStoryLine.Story_Luna;
        GetIndexStoryLineData(idStoryLine);
    }
    public override void GetLine(int indexLine)
    {
        indexStoryLineTextCurrent = indexLine;

        DialogController.Instance.ResetDialog();

        if (indexStoryLineTextCurrent < 0)
        {
            StoryLineController.Instance.EndStoryLine();

            if (indexStoryLineTextCurrent == -1)
            {
                Data.IndexMiniGame = 0;
                SceneController.Instance.LoadGameScene();
            }

            return;
        }

        var nameTalker = StoryLineController.StoryLineConfig.StoryLineDatas[indexStoryLineDataCurrent].StoryLineTexts[indexStoryLineTextCurrent].idCharacter;
        var talkText = StoryLineController.StoryLineConfig.StoryLineDatas[indexStoryLineDataCurrent].StoryLineTexts[indexStoryLineTextCurrent].txt;
        StoryLineController.Instance.ChangeTalk(nameTalker.ToString(), talkText);

        switch (indexStoryLineTextCurrent)
        {
            case 0:
                Line_0();
                break;
            case 1:
                Line_1();
                break;
            case 2:
                Line_2();
                break;
            case 3:
                Line_3();
                break;
            case 5:
                Line_5();
                break;
            case 6:
                Line_6();
                break;
            default: break;
        }

        StoryLineController.Instance.ShowTalk();

        StoryLineController.Instance.ShowTalkCursor(!DialogController.Instance.isCreateReplyDialog);
    }
    private void Line_0()
    {

    }
    private void Line_1()
    {

    }
    private void Line_2()
    {

    }
    private void Line_3()
    {

    }
    private void Line_5()
    {

    }
    private void Line_6()
    {

    }
}
