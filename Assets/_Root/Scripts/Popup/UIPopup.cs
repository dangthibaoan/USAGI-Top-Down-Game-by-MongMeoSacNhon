using TMPro;
using UnityEngine;

public class UIPopup : Popup
{
    [Header("Button Setting")]
    [SerializeField] private bool activeSetting = false;
    [SerializeField] private GameObject btnSetting;
    [SerializeField] private TMP_Text btnSettingText;

    [Header("Button WASD")]
    [SerializeField] private GameObject WASD;
    [SerializeField] private GameObject W, A, S, D;

    private void Start()
    {
        activeSetting = false;
    }
    public void BtnSettingClick()
    {
        activeSetting = !activeSetting;
        if (activeSetting)
        {
            btnSettingText.text = "×";
            Debug.Log("Open Setting");
            PopupController.Instance.Show<SettingPopup>();
        }
        else
        {
            btnSettingText.text = "=";
            Debug.Log("Close Setting");
            PopupController.Instance.Hide<SettingPopup>();
        }
    }
    public void BtnSettingSetActive(bool status)
    {
        btnSetting.SetActive(status);
    }
    public void BtnWASDSetActive(bool status)
    {
        WASD.SetActive(status);
    }
    public void BtnWASDSetActive(bool w, bool a, bool s, bool d)
    {
        W.SetActive(w);
        A.SetActive(a);
        S.SetActive(s);
        D.SetActive(d);
    }
}
