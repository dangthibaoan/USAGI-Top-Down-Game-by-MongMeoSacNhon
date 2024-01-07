using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    void Start()
    {
        SoundController.Instance.PlayBackground(SoundType.BackgroundMusic);
        PopupController.Instance.Show<UIPopup>();
        PopupController.Instance.GetPopup<UIPopup>().BtnWASDSetActive(true, true, true, true);
        ConfigController.PlayerDataConfig.isActiveMovement = true;
    }
}
