using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class FinishGamePopup : Popup
{
    [SerializeField] private Image ImageCongrats;
    [SerializeField] private TMP_Text CurrentScore, MaxScore;
}
