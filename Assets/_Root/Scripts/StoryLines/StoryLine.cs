using System.Linq;
using UnityEngine;

public class StoryLine : MonoBehaviour, IAfterClickDialog
{
    [SerializeField] protected IDStoryLine idStoryLine;
    [SerializeField] protected int indexStoryLineTextCurrent;
    [SerializeField] protected int indexStoryLineDataCurrent;
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
    public int GetIndexStoryLineDataCurrent() => indexStoryLineDataCurrent;

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
