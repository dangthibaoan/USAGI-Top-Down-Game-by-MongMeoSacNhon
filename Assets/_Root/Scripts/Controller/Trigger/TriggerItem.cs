using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItem : Trigger
{
    protected override void Awake()
    {
        trigger_text = gameObject.transform.parent.name;
        trigger_type = TriggerType.NonPlayer;
        isDialogExist = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " trigger");
        if (other.TryGetComponent<Trigger>(out Trigger triggerOther))
        {
            if (triggerOther.trigger_type == TriggerType.Player && !isDialogExist)
            {
                isDialogExist = true;
                DialogController.Instance.CreateDialogInteract(trigger_index, trigger_text, transform.parent.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Trigger>(out Trigger triggerOther))
        {
            if (triggerOther.trigger_type == TriggerType.Player && isDialogExist)
            {
                isDialogExist = false;
                DialogController.Instance.DeleteDialog(trigger_text, transform.parent.gameObject);
            }
        }
    }
}
