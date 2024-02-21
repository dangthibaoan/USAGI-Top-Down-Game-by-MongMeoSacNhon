using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoryLine : MonoBehaviour, IAfterClickDialog
{
    public IDStoryLine idStoryLine;
    public int indexStoryLineTextCurrent, indexStoryLineDataCurrent;
    protected void GetIndexStoryLineData(IDStoryLine idStoryLine)
    {
        StoryLineController.StoryLineConfig.StoryLineDatas.ToList().ForEach(_data =>
        {
            if (_data.idStoryLine == idStoryLine)
            {
                indexStoryLineDataCurrent = StoryLineController.StoryLineConfig.StoryLineDatas.IndexOf(_data);
            }
        });
    }
    public virtual void GetLine(int indexLine) { }

    public void AfterClickDialog()
    {
        DialogController.Instance.HideAllDialog();
        DialogController.Instance.isTalking = true;
        StoryLineController.Instance.SetStoryLine(this);
        StoryLineController.Instance.SetIndexTextDetailCurrent(0);
        StoryLineController.Instance.GetLine();
    }
}
