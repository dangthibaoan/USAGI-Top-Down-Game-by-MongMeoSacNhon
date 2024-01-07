using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerNPC : Trigger
{
    [SerializeField] private IDText idText;
    [SerializeField] private int stt;
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " trigger");
        if (other.gameObject.name == ConfigController.ItemConfig.ItemDatas[0].Item.name)
        {
            DialogController.Instance.CreateDialog(td_index, td_txtDialog, transform.parent.gameObject, idText, stt);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == ConfigController.ItemConfig.ItemDatas[0].Item.name)
        {
            DialogController.Instance.DeleteDialog(td_txtDialog, transform.parent.gameObject);
        }
    }
}
