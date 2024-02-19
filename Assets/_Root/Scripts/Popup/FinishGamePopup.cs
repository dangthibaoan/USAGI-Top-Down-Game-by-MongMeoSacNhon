using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishGamePopup : Popup
{
    [SerializeField] private Image ImageCongrats;
    [SerializeField] private Image ImageNewRecord;
    [SerializeField] private TMP_Text Timer, CurrentScore, MaxScore;
    [SerializeField] private SoundType FinishMusic;

    private void Awake()
    {
        this.ImageNewRecord.gameObject.SetActive(false);
        this.ImageCongrats.gameObject.SetActive(true);
    }

    protected override void AfterShown()
    {
        base.AfterShown();
        SoundController.Instance.PlayOnce(this.FinishMusic);
        MiniGame_Luna.Timer = (int)MiniGame_Luna.Timer;
        this.Timer.text = (MiniGame_Luna.Timer - MiniGame_Luna.Timer % 60) / 60 + ":" + MiniGame_Luna.Timer % 60;
        this.CurrentScore.text = ScoreController.currentScore + "";
        if (ScoreController.currentScore >= Data.MaxScore)
        {
            Data.MaxScore = ScoreController.currentScore;
            this.ImageNewRecord.gameObject.SetActive(true);
        }
        else
        {
            this.ImageNewRecord.gameObject.SetActive(false);
        }
        this.MaxScore.text = Data.MaxScore + "";
    }

    public void BtnOKClick()
    {
        PopupController.Instance.HideAll();
        SceneController.Instance.LoadHomeScene();
    }
}
