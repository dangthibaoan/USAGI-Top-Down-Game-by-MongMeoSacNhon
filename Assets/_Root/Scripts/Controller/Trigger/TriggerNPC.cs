using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerNPC : Trigger
{
    [SerializeField] private IDStoryLine idStoryLine;
    [SerializeField] private IDCharacter iDCharacter;
    [SerializeField] private int stt;
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " trigger");
        if (other.gameObject.name == ConfigController.CharacterConfig.CharacterDatas[0].Character.name)
        {
            DialogController.Instance.CreateDialog(td_index, td_txtDialog, transform.parent.gameObject, idStoryLine, stt);
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
