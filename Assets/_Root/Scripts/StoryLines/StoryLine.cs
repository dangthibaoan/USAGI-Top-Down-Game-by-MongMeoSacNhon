using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoryLine : MonoBehaviour
{
    public IDText iDText;
    public int indexTextDetailCurrent, indexTextDataCurrent;
    protected void GetIndexTextData(IDText iDText)
    {
        ConfigController.StoryLineConfig.TextDatas.ToList().ForEach(_textData =>
        {
            if (_textData.idText == iDText)
            {
                indexTextDataCurrent = ConfigController.StoryLineConfig.TextDatas.IndexOf(_textData);
            }
        });
    }
    public virtual void GetLine(int indexLine) { }
}
