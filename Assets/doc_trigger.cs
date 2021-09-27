using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class doc_trigger : MonoBehaviour, IinteractionTrigger
{
    public Button button;
    public TMP_Text text;

    public interactButton ib;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        button.gameObject.SetActive(true);
        text.SetText("Enter");
        ib.callback = this;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;
    }

    public void callback()
    {
        Debug.Log("entered to doc");
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;

        //dm.StartDialogue(dc);
        ll.LoadLevelByName("doc");
    }

    //public DialogueManager dm;
    //public dialogue_choices dc;
    public LevelLoader ll;
}
