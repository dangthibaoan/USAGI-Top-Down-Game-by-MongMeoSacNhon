using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class LudoStoryLines : StoryLine
{
    private void Awake()
    {
        iDText = IDText.Ludo;
        GetIndexTextData(iDText);
    }
    public override void GetLine(int indexLine)
    {
        indexTextDetailCurrent = indexLine;

        DialogController.Instance.ResetDialog();

        if (indexTextDetailCurrent < 0)
        {
            StoryLineController.Instance.HideTalk();

            if (indexTextDetailCurrent == -1)
            {
                Data.IndexMap = 1;
                SceneController.Instance.LoadGameScene();
            }

            return;
        }

        var nameTalker = ConfigController.StoryLineConfig.TextDatas[indexTextDataCurrent].TextDetails[indexTextDetailCurrent].Item.name;
        var talkText = ConfigController.StoryLineConfig.TextDatas[indexTextDataCurrent].TextDetails[indexTextDetailCurrent].txt;
        StoryLineController.Instance.ChangeTalk(nameTalker, talkText);

        switch (indexTextDetailCurrent)
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
