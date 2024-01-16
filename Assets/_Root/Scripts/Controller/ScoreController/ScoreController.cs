using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static int currentScore;
    [SerializeField] private GameEvent EventScoreChange;
    [SerializeField] private TMP_Text TxtCurrentScore;
    [SerializeField] private TMP_Text TxtMaxScore;
    private void Start()
    {
        currentScore = 0;
        ScoreChange();
    }
    private void OnEnable()
    {
        EventScoreChange.Subscribe(ScoreChange);
    }
    private void OnDisable()
    {
        EventScoreChange.Unsubscribe(ScoreChange);
    }
    public void ScoreChange()
    {
        TxtMaxScore.text = Data.MaxScore + "";
        TxtCurrentScore.text = currentScore + "";
    }
}
