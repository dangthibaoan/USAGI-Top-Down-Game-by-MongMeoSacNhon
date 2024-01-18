using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class FinishGamePopup : Popup
{
    [SerializeField] private GameObject ImageCongrats;
    [SerializeField] private GameObject ImageNewRecord;
    [SerializeField] private TMP_Text CurrentScore, MaxScore;
    [SerializeField] private SoundType FinishMusic;

    private void Awake()
    {
        this.ImageNewRecord.SetActive(false);
        this.ImageCongrats.SetActive(true);
    }

    protected override void AfterShown()
    {
        base.AfterShown();
        SoundController.Instance.PlayOnce(this.FinishMusic);
        this.CurrentScore.text = ScoreController.currentScore + "";
        if (ScoreController.currentScore >= Data.MaxScore)
        {
            Data.MaxScore = ScoreController.currentScore;
            this.ImageNewRecord.SetActive(true);
        }
        else
        {
            this.ImageNewRecord.SetActive(false);
        }
        this.MaxScore.text = Data.MaxScore + "";
    }

    public void BtnOKClick()
    {
        this.Hide();
        SceneController.Instance.LoadHomeScene();
    }
}