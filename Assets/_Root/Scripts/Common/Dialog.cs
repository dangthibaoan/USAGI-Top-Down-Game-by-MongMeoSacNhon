using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Linq;
using UnityEngine.Assertions.Must;
using DG.Tweening;

public class Dialog : MonoBehaviour, IChangeColor
{
    [Header("Dialog UI")]
    [SerializeField] private Image Background;
    private Color colorOrigin;

    [Header("Dialog Data")]
    public int d_Index;
    public Image d_Icon;
    public TMP_Text d_Txt;
    public GameObject d_GameObj;
    public DialogType d_type;
    public IDStoryLine d_idStoryLine;
    public int d_indexStoryLineText;

    private void Start()
    {
        colorOrigin = Background.color;
    }

    public virtual void Click()
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

    public void ChangeColor()
    {
        Background.DOColor(Color.yellow, 0);
    }

    public void RechangeColor()
    {
        Background.DOColor(colorOrigin, 0);
    }
}
