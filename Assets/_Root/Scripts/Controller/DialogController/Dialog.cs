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
    public int d_Index;
    public Image d_Icon;
    public TMP_Text d_Txt;
    public GameObject d_GameObj;
    public DialogType d_type;
    public IDStoryLine d_idStoryLine;
    public int d_indexStoryLineText;

    protected void Start()
    {
        colorOrigin = Background.color;
    }

    public virtual void Click() { }

    public void ChangeColor()
    {
        Background.DOColor(Color.yellow, 0);
    }

    public void RechangeColor()
    {
        Background.DOColor(colorOrigin, 0);
    }
}
