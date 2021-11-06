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

        //dm.StartDialogue(dc);

        if(globalVars.progress == 0f)
        {
            hudscipt.instance.update_todo("Get some money from the family savings chest.");
            dm.StartDialogue(dialog);
            globalVars.progress = 1f;
        }
        else if(globalVars.progress > 0f && globalVars.progress < 4f)
        {
            dm.StartDialogue(dialog_2);
        }
        else if(globalVars.progress == 4f)
        {
            dm.StartDialogue(dialog_3);
            if (hudscipt.instance.mone.text != "0f")
                dm.nextDialogue = money_left_over;
            hudscipt.instance.update_todo("You did it!");
            globalVars.progress = 5f;
        }
        else
        {
            dm.StartDialogue(def);
        }
    }

    public DialogueManager dm;
    //public dialogue_choices dc;
    public dialogue dialog,         // first time talking to mom
        dialog_2,                   // after having talked
        dialog_3;                   // returning with medicine

    public dialogue money_left_over;

    public dialogue def;
}
