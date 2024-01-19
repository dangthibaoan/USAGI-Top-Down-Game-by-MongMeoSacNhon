using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoryLine : MonoBehaviour
{
    public IDStoryLine idStoryLine;
    public int indexStoryLineTextCurrent, indexStoryLineDataCurrent;
    protected void GetIndexStoryLineData(IDStoryLine idStoryLine)
    {
        ConfigController.StoryLineConfig.StoryLineDatas.ToList().ForEach(_data =>
        {
            if (_data.idStoryLine == idStoryLine)
            {
                indexStoryLineDataCurrent = ConfigController.StoryLineConfig.StoryLineDatas.IndexOf(_data);
            }
        });
    }
    public virtual void GetLine(int indexLine) { }
}
