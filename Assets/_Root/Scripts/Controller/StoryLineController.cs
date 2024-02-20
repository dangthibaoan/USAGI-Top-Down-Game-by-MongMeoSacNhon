using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class StoryLineController : Singleton<StoryLineController>
{
    [Header("UI Story Line")]
    [SerializeField] private Transform TalkBox;
    [SerializeField] private TMP_Text NameTalker, TalkText;
    [SerializeField] private Image TalkCursor;
    [SerializeField] private Vector3 TalkCursorPositionOrigin, TalkBoxPositionOrigin;

    [Header("Story Line Current")]
    [SerializeField] private StoryLineConfig storyLineConfig;
    public static StoryLineConfig StoryLineConfig;
    [SerializeField] private int indexTextDetailCurrent;
    [SerializeField] private StoryLine StoryLineCurrent;

    protected override void Awake()
    {
        base.Awake();
        StoryLineConfig = storyLineConfig;
    }

    private void Start()
    {
        TalkCursorPositionOrigin = TalkCursor.transform.position;
        TalkBoxPositionOrigin = TalkBox.transform.position;
        ResetTalkArea();
    }
    public void SetStoryLine(StoryLine storyLine)
    {
        StoryLineCurrent = storyLine;
    }
    public void SetIndexLineCurrent(int indexLine)
    {
        indexTextDetailCurrent = indexLine;
        DialogController.Instance.isCreateReplyDialog = false;
    }
    public void GetLine()
    {
        HideTalk();

        if (!DialogController.Instance.isTalking) return;

        if (DialogController.Instance.isCreateReplyDialog) return;

        ShowTalkCursor(false);
        StoryLineCurrent.GetLine(indexTextDetailCurrent);
    }
    public void ClickTalkGetLine()
    {
        if (!TalkCursor.gameObject.activeSelf) return;

        GetLine();
    }
    public void HideTalk()
    {
        TalkBox.gameObject.SetActive(false);
        TalkBox.DOMove(TalkBoxPositionOrigin + Vector3.down * 1, 0);
    }
    public void ShowTalk()
    {
        PopupController.Instance.Hide<UIPopup>();

        ConfigController.Config_PlayerData.isActiveMovement = false;

        DialogController.Instance.isTalking = true;
        DialogController.Instance.isCreateReplyDialog = false;

        TalkBox.gameObject.SetActive(true);
        TalkBox.DOMove(TalkBoxPositionOrigin, 0.5f);

        int next = StoryLineConfig.StoryLineDatas[StoryLineCurrent.indexStoryLineDataCurrent].StoryLineTexts[indexTextDetailCurrent].nextLineNumber;
        indexTextDetailCurrent = next;

        if (next < 0) return;

        CheckForCreateDialogReply();
    }
    private void CheckForCreateDialogReply()
    {
        StoryLineConfig.StoryLineDatas[StoryLineCurrent.indexStoryLineDataCurrent].StoryLineTexts.ToList().ForEach(texts =>
        {
            if (texts.lineNumber == indexTextDetailCurrent && texts.idCharacter == ConfigController.CharacterConfig.CharacterDatas[0].idCharacter)
            {
                DialogController.Instance.isCreateReplyDialog = true;
                DialogController.Instance.CreateDialog(0, texts.txt, ConfigController.CharacterConfig.CharacterDatas[0].Character, StoryLineCurrent.idStoryLine, texts.nextLineNumber);
            }
        });
    }
    public void ChangeTalk(string nameTalker, string text)
    {
        NameTalker.text = nameTalker;
        TalkText.text = text;
    }
    public void EndStoryLine()
    {
        ConfigController.Config_PlayerData.isActiveMovement = true;
        ResetTalkArea();
        PopupController.Instance.Show<UIPopup>();
        DialogController.Instance.ShowAllDialog();
    }
    public void ResetTalkArea()
    {
        DialogController.Instance.isTalking = false;
        DialogController.Instance.isCreateReplyDialog = false;
        TalkBox.gameObject.SetActive(false);
        TalkText.text = "";
        ShowTalkCursor(false);
    }
    public void ShowTalkCursor(bool status)
    {
        TalkCursor.transform.position = TalkCursorPositionOrigin;
        if (status)
        {
            TalkCursor.transform.DOMove(TalkCursorPositionOrigin, 0).SetDelay(1).OnComplete(() =>
            {
                TalkCursor.gameObject.SetActive(true);
                TalkCursor.transform.DOMove(TalkCursorPositionOrigin + Vector3.down * 0.06f, 0.4f).SetLoops(-1, LoopType.Yoyo);
            });
        }
        else
        {
            TalkCursor.gameObject.SetActive(false);
            TalkCursor.transform.DOKill();
        }
    }
}
