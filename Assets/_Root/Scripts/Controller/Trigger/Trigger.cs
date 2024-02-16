using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    protected int trigger_index;
    protected string trigger_text;
    public TriggerType trigger_type;
    protected virtual void Awake()
    {

    }
    public void ChangeTextDialog(string triggerText)
    {
        trigger_text = triggerText;
    }
}