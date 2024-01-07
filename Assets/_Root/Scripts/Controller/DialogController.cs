using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
using UnityEditor;

public class DialogController : Singleton<DialogController>
{
    [SerializeField] private Dialog dialogOriginal;
    [SerializeField] private Transform Content;
    public bool isTalking = false, isCreateReplyDialog = false;

    public void CreateDialog(int sttItem, string txtDialog, GameObject obj, IDText idText, int indexText)
    {
        // isCreateReplyDialog = true;

        var dialogInstance = Instantiate(dialogOriginal, Content);

        if (obj.name == ConfigController.ItemConfig.ItemDatas[0].Item.name)
            dialogInstance.gameObject.SetActive(true);
        else
            dialogInstance.gameObject.SetActive(!isTalking);

        dialogInstance.d_type = DialogType.Talk;
        dialogInstance.d_Index = Content.childCount - 1;
        dialogInstance.d_Icon.sprite = ConfigController.ItemConfig.ItemDatas[sttItem].Icon;
        dialogInstance.d_Txt.text = txtDialog;
        dialogInstance.d_GameObj = obj;
        dialogInstance.d_idText = idText;
        dialogInstance.d_indexText = indexText;
        Debug.Log("Created dialog talk number " + dialogInstance.d_Index + ": <<" + txtDialog + ">> with game object <<" + obj.name + ">>");
    }
    public void CreateDialog(int sttItem, string txtDialog, GameObject obj)
    {
        // isCreateReplyDialog = true;

        var dialogInstance = Instantiate(dialogOriginal, Content);

        dialogInstance.gameObject.SetActive(!isTalking);

        dialogInstance.d_type = DialogType.Loot;
        dialogInstance.d_Index = Content.childCount - 1;
        dialogInstance.d_Icon.sprite = ConfigController.ItemConfig.ItemDatas[sttItem].Icon;
        dialogInstance.d_Txt.text = txtDialog;
        dialogInstance.d_GameObj = obj;
        Debug.Log("Created dialog loot number " + dialogInstance.d_Index + ": <<" + txtDialog + ">> with game object <<" + obj.name + ">>");
    }
    public void ResetDialog()
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            var dialog = Content.GetChild(i).GetComponent<Dialog>();
            if (dialog.gameObject.activeSelf)
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
