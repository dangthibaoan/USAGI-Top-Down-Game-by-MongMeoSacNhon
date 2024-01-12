using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LineCustom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private IChangeColor image;
    [SerializeField] private Transform TargetGraphic;
    [SerializeField] private SoundType soundType;
    [SerializeField] private Button.ButtonClickedEvent onClick;
    [SerializeField] private Button.ButtonClickedEvent onPress;

    public bool canClick = true;
    private bool isMoveEnter = false;

    private void Start()
    {
        if (TargetGraphic.TryGetComponent<IChangeColor>(out IChangeColor img))
        {
            image = img;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (canClick)
        {
            onPress?.Invoke();

            if (image == null) return;
            image.ChangeColor();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (canClick)
        {
            SoundController.Instance.PlayOnce(soundType);

            if (isMoveEnter)
            {
                onClick?.Invoke();
            }

            if (image == null) return;
            image.RechangeColor();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMoveEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMoveEnter = false;
    }
}