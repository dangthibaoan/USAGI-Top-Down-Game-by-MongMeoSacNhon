using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLuna : Map
{
    private void Start()
    {
        PopupController.Instance.GetPopup<UIPopup>().BtnWASDSetActive(false, true, false, true);
    }
}
