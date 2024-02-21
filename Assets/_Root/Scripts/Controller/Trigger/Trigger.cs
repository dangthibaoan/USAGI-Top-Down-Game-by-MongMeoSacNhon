using UnityEngine;

public class Trigger : MonoBehaviour
{
    protected int trigger_index;
    protected string trigger_text;
    public TriggerType trigger_type;
    [SerializeField] protected bool isDialogExist;
    protected void Awake()
    {
        if (trigger_type == TriggerType.Player) return;

        trigger_text = gameObject.transform.parent.name;
        isDialogExist = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Trigger>(out Trigger triggerOther))
        {
            Debug.Log(other.gameObject.name + " trigger" + triggerOther.trigger_type);
            if (triggerOther.trigger_type == TriggerType.Player && !isDialogExist)
            {
                isDialogExist = true;
                DialogController.Instance.CreateDialogInteract(0, DialogType.nonDialogType, trigger_text, transform.parent.gameObject);
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
    public void ChangeTextDialog(string triggerText)
    {
        trigger_text = triggerText;
    }
}