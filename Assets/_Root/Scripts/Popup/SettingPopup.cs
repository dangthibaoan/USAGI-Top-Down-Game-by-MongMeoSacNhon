using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : Popup
{
    [SerializeField] private GameObject SoundON, SoundOFF;
    private void Start()
    {
        ChangeSoundImage();
    }
    public void SoundClick()
    {
        Data.SetBool(Constant.SOUND_STATE, !Data.SoundState);
        ChangeSoundImage();
    }
    private void ChangeSoundImage()
    {
        SoundON.SetActive(Data.SoundState);
        SoundOFF.SetActive(!Data.SoundState);
        Debug.Log(Data.SoundState == true ? "SoundOn" : "SoundOff");
        SoundController.Instance.BackgroundAudio.volume = Data.SoundState == true ? 1 : 0;
        SoundController.Instance.OnceAudio.volume = Data.SoundState == true ? 1 : 0;
    }
}
