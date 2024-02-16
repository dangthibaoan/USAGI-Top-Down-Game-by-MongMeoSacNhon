using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerNPC : Trigger
{
    [SerializeField] private IDStoryLine idStoryLine;
    [SerializeField] private int indexStartStoryLine;
    [SerializeField] private bool isDialogExist;
    protected override void Awake()
    {
        base.Awake();
        trigger_text = gameObject.transform.parent.name;
        trigger_type = TriggerType.NonPlayer;
        isDialogExist = false;
        ConfigController.CharacterConfig.CharacterDatas.ForEach(item =>
        {
            if (item.Character.name == transform.parent.gameObject.name && trigger_type == TriggerType.NonPlayer)
            {
                trigger_index = ConfigController.CharacterConfig.CharacterDatas.IndexOf(item);
            }
        });
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Trigger>(out Trigger triggerOther))
        {
            Debug.Log(other.gameObject.name + " trigger" + triggerOther.trigger_type);
            if (triggerOther.trigger_type == TriggerType.Player && !isDialogExist)
            {
                isDialogExist = true;
                DialogController.Instance.CreateDialog(
                    trigger_index,
                    trigger_text,
                    transform.parent.gameObject,
                    idStoryLine,
                    indexStartStoryLine);
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
