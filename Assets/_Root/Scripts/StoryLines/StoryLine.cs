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

    public void AfterClickDialog(int code)
    {
        DialogController.Instance.HideAllDialog();
        DialogController.Instance.isTalking = true;
        StoryLineController.Instance.SetStoryLine(this);
        StoryLineController.Instance.SetIndexTextDetailCurrent(code);
        StoryLineController.Instance.GetLine();
    }
}
