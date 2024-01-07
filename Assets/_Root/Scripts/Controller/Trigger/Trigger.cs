using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    protected int td_index;
    protected string td_txtDialog;
    protected virtual void Awake()
    {
        td_index = 0;
        ConfigController.ItemConfig.ItemDatas.ForEach(item =>
        {
            if (item.Item.name == transform.parent.gameObject.name)
            {
                td_index = ConfigController.ItemConfig.ItemDatas.IndexOf(item);
            }
        });
        td_txtDialog = transform.parent.gameObject.name;
    }
    public void ChangeTextDialog(string txtDialog)
    {
        td_txtDialog = txtDialog;
    }
}
