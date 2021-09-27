using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mom_script : MonoBehaviour, IinteractionTrigger
{
    public Button button;
    public TMP_Text text;

    public interactButton ib;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        button.gameObject.SetActive(true);
        text.SetText("Talk");
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
        Debug.Log("talked to mom");
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;

        dm.StartDialogue(dc);
    }

    public DialogueManager dm;
    public dialogue_choices dc;
    public dialogue dialog;
}
