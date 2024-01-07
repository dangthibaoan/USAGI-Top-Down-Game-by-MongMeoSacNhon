using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePopup : Popup
{
    public void BackHome()
    {
        Hide();
        SceneController.Instance.LoadHomeScene();
    }

}
