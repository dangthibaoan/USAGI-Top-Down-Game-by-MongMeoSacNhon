using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DialogStoryLine : Dialog
{
    public IDStoryLine d_idStoryLine;
    public int d_indexStoryLineText;
    public override void Click()
    {
        Debug.Log("Click dialog " + d_Txt.text);

        StoryLineController.Instance.SetIndexTextDetailCurrent(d_indexStoryLineText);
        StoryLineController.Instance.GetLine();
    }
}
