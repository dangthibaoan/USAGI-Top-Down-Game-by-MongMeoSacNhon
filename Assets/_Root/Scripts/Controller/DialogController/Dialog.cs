using UnityEngine.UI;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Dialog : MonoBehaviour, IChangeColor
{
    [Header("Dialog UI")]
    [SerializeField] protected Image Background;
    protected Color colorOrigin;

    [Header("Dialog Data")]
    public int d_code;// code = 0: dialog interact, code != 0: dialog storyline
    public Image d_Icon;
    public TMP_Text d_Txt;
    public GameObject d_GameObj;
    public DialogType d_type;

    protected void Start()
    {
        colorOrigin = Background.color;
    }

    public void Click()
    {
        Debug.Log("Click dialog " + d_Txt.text);

        d_GameObj.GetComponentInChildren<IAfterClickDialog>().AfterClickDialog(d_code);
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
