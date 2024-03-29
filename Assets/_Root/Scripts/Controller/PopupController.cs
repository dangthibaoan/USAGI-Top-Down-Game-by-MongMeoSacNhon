using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class PopupController : Singleton<PopupController>
{
    public Transform CanvasTransform;
    public CanvasScaler CanvasScaler;
    public Camera Camera;
    public Popup[] Popups;
    private Dictionary<Type, Popup> dictionary = new Dictionary<Type, Popup>();
    public int NumberActive => dictionary.Count(pair => pair.Value.gameObject.activeSelf);

    protected override void Awake()
    {
        base.Awake();

        Init();
        CanvasScaler.matchWidthOrHeight = Camera.main.aspect > .7f ? 1 : 0;
    }

    public void Init()
    {
        int index = 0;
        Popups.ToList().ForEach(popup =>
        {
            Popup popupInstance = Instantiate(popup, CanvasTransform);
            popupInstance.gameObject.SetActive(false);
            popupInstance.Init();
            popupInstance.Canvas.sortingOrder = popupInstance.Canvas.sortingOrder + index++;
            popupInstance.CanvasGroup.alpha = 0;
            popupInstance.CanvasGroup.interactable = false;
            dictionary.Add(popupInstance.GetType(), popupInstance);
        });
    }

    public void Show<T>(object data = null)
    {
        if (dictionary.TryGetValue(typeof(T), out Popup popup))
        {
            popup.data = data;
            popup.Show();
        }
    }

    public void Hide<T>()
    {
        if (dictionary.TryGetValue(typeof(T), out Popup popup))
        {
            popup.Hide();
        }
    }

    public void HideAll()
    {
        foreach (var item in dictionary)
        {
            item.Value.Hide();
        }
    }

    public T GetPopup<T>() where T : Popup
    {
        if (dictionary.TryGetValue(typeof(T), out Popup popup))
        {
            return (T)popup;
        }
        return default;
    }
}
