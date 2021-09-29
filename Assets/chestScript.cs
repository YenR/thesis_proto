using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class chestScript : MonoBehaviour, IinteractionTrigger
{
    public Button button;
    public TMP_Text text;

    public interactButton ib;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (globalVars.progress != 1f)
            return;

        button.gameObject.SetActive(true);
        text.SetText("Take money");
        ib.callback = this;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (globalVars.progress != 1f)
            return;

        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;
    }

    public void callback()
    {
        Debug.Log("got to chest");
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;

        //dm.StartDialogue(dc);

        if (globalVars.progress == 1f && globalVars.MCx_level == 1)
        {
            hudscipt.instance.update_todo("Go to the next town, on the other side of the forest.");
            dm.StartDialogue(dialog_mcx1);
            globalVars.progress = 2f;
        }
        else if (globalVars.progress == 1f && globalVars.MCx_level == 2)
        {
            hudscipt.instance.update_todo("Go to the next town, on the other side of the forest.");
            dm.StartDialogue(dialog_mcx2);
            globalVars.progress = 2f;
        }
    }

    public DialogueManager dm;

    public dialogue dialog_mcx1;            // MCx 1 dialogue
    public dialogue_choices dialog_mcx2;    // MCx 2 dialogue
}
