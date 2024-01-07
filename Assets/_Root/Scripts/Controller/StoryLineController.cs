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
    [SerializeField] private Transform Canvas;
    [SerializeField] private Transform TalkArea;
    [SerializeField] private TMP_Text NameTalker, TalkText;
    [SerializeField] private Image TalkCursor;
    [SerializeField] private Vector3 TalkCursorPositionOrigin;

    [Header("Story Line Current")]
    [SerializeField] private int indexTextDetailCurrent;
    [SerializeField] private StoryLine StoryLineCurrent;

    private void Start()
    {
        TalkCursorPositionOrigin = TalkCursor.transform.position;
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
    public void ShowTalk()
    {
        PopupController.Instance.Hide<UIPopup>();
        ConfigController.PlayerDataConfig.isActiveMovement = false;
        DialogController.Instance.isTalking = true;
        DialogController.Instance.isCreateReplyDialog = false;

        TalkArea.gameObject.SetActive(true);

        Canvas.gameObject.GetComponent<Button>().enabled = true;

        int next = ConfigController.StoryLineConfig.TextDatas[StoryLineCurrent.indexTextDataCurrent].TextDetails[indexTextDetailCurrent].sttNext;
        indexTextDetailCurrent = next;

        if (next < 0) return;

        CheckForCreateDialogReply();
    }
    private void CheckForCreateDialogReply()
    {
        ConfigController.StoryLineConfig.TextDatas[StoryLineCurrent.indexTextDataCurrent].TextDetails.ToList().ForEach(texts =>
        {
            if (texts.stt == indexTextDetailCurrent && texts.Item == ConfigController.ItemConfig.ItemDatas[0].Item)
            {
                DialogController.Instance.isCreateReplyDialog = true;
                DialogController.Instance.CreateDialog(0, texts.txt, texts.Item, StoryLineCurrent.iDText, texts.sttNext);
            }
        });
    }
    public void ChangeTalk(string nameTalker, string text)
    {
        NameTalker.text = nameTalker;
        TalkText.text = text;
    }
    public void HideTalk()
    {
        ConfigController.PlayerDataConfig.isActiveMovement = true;
        ResetTalkArea();
        PopupController.Instance.Show<UIPopup>();
        DialogController.Instance.ShowAllDialog();
    }
    public void ResetTalkArea()
    {
        DialogController.Instance.isTalking = false;
        DialogController.Instance.isCreateReplyDialog = false;
        TalkArea.gameObject.SetActive(false);
        TalkText.text = "";
        ShowTalkCursor(false);
    }
    public void ShowTalkCursor(bool status)
    {
        TalkCursor.transform.position = TalkCursorPositionOrigin;
        if (status)
        {
            TalkCursor.transform.DOMove(TalkCursorPositionOrigin, 0).SetDelay(2).OnComplete(() =>
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
