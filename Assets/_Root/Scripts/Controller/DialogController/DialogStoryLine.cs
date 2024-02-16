using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DialogStoryLine : Dialog
{
    public override void Click()
    {
        Debug.Log("Click dialog " + d_Txt.text);
        if (d_type == DialogType.Talk)
        {
            if (d_GameObj.name != ConfigController.CharacterConfig.CharacterDatas[0].Character.name)
            {
                DialogController.Instance.HideAllDialog();
                DialogController.Instance.isTalking = true;
                StoryLineController.Instance.SetStoryLine(d_GameObj.GetComponentInChildren<StoryLine>());
            }
            StoryLineController.Instance.SetIndexLineCurrent(d_indexStoryLineText);
            StoryLineController.Instance.GetLine();
        }
        else if (d_type == DialogType.Loot)
        {
            //code loot item
            Destroy(this);
        }

    }
}
