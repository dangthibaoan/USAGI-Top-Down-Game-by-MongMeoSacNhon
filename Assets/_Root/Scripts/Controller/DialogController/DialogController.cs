using System;
using UnityEngine;
[Serializable]

public class DialogController : Singleton<DialogController>
{
    [SerializeField] private Transform Content;
    [SerializeField] private Dialog dialogInteract;
    public bool isTalking = false, isCreateReplyDialog = false;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        isTalking = false;
        isCreateReplyDialog = false;
    }
    public void CreateDialogInteract(int code, DialogType dialogType, string txtDialog, GameObject gameObj)
    {
        var dialogInstance = Instantiate(dialogInteract, Content);

        dialogInstance.gameObject.SetActive(code != 0 || (code == 0 && !isTalking));

        dialogInstance.d_type = dialogType;
        dialogInstance.d_code = code;
        if (dialogType == DialogType.nonDialogType)
        {
            // dialogInstance.d_Icon.sprite = ConfigController.CharacterConfig.CharacterDatas[code].Icon;
        }
        dialogInstance.d_Txt.text = txtDialog;
        dialogInstance.d_GameObj = gameObj;
        Debug.Log("Created dialog interact number " + dialogInstance.d_code + ": <<" + txtDialog + ">> with game object <<" + gameObj + ">>");
    }
    public void ResetDialog()
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            var dialog = Content.GetChild(i).GetComponent<Dialog>();
            if (dialog.d_type != DialogType.nonDialogType)
            {
                Destroy(dialog.gameObject);
            }
        }
    }
    public void HideAllDialog()
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            var dialog = Content.GetChild(i).GetComponent<Dialog>();
            dialog.gameObject.SetActive(false);
        }
    }
    public void ShowAllDialog()
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            var dialog = Content.GetChild(i).GetComponent<Dialog>();
            dialog.gameObject.SetActive(true);
        }
    }
    public void DeleteDialog(string txtDialog, GameObject obj)
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            var dialog = Content.GetChild(i).GetComponent<Dialog>();
            if (dialog.d_Txt.text == txtDialog && dialog.d_GameObj == obj)
            {
                Destroy(dialog.gameObject);
            }
        }
    }
}
