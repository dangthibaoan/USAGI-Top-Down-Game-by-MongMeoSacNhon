using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItem : Trigger
{
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " trigger");
        if (other.gameObject.name == ConfigController.CharacterConfig.CharacterDatas[0].Character.name)
        {
            DialogController.Instance.CreateDialog(td_index, td_txtDialog, transform.parent.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == ConfigController.CharacterConfig.CharacterDatas[0].Character.name)
        {
            DialogController.Instance.DeleteDialog(td_txtDialog, transform.parent.gameObject);
        }
    }
}
