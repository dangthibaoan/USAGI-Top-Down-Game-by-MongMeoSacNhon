using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Linq;
using UnityEngine.Assertions.Must;

public class Dialog : MonoBehaviour
{
    public int d_Index;
    public Image d_Icon;
    public TMP_Text d_Txt;
    public GameObject d_GameObj;
    public DialogType d_type;
    public IDText d_idText;
    public int d_indexText;

    public virtual void Click()
    {
        Debug.Log("Click dialog " + d_Txt.text);
        if (d_type == DialogType.Talk)
        {
            if (d_GameObj.name != ConfigController.ItemConfig.ItemDatas[0].Item.name)
            {
                DialogController.Instance.HideAllDialog();
                DialogController.Instance.isTalking = true;
                StoryLineController.Instance.SetStoryLine(d_GameObj.GetComponentInChildren<StoryLine>());
            }
            StoryLineController.Instance.SetIndexLineCurrent(d_indexText);
            StoryLineController.Instance.GetLine();
        }
        else if (d_type == DialogType.Loot)
        {
            //code loot item
            Destroy(this);
        }

    }
}
