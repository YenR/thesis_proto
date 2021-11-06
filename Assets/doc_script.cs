using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class doc_script : MonoBehaviour, IinteractionTrigger
{
    public Button button;
    public TMP_Text text;

    public interactButton ib;

    public static bool friendly = true;

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
        Debug.Log("talked to doc");
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;

        if (globalVars.progress >= 3f && globalVars.progress < 4f)
        {
            hudscipt.instance.update_todo("Get back to mom with the medicine.");
            globalVars.progress = 4f;
            if(globalVars.MCx_level == 2)
                dm.StartDialogue(dc_high_mcx);
            else
                dm.StartDialogue(dc_low_mcx);
        }
        else
        {
            if (friendly)
                dm.StartDialogue(d_bye_friendly);
            else
                dm.StartDialogue(d_bye_hostile);
        }
    }

    public DialogueManager dm;

    public dialogue_choices dc_high_mcx, dc_low_mcx;
    public dialogue d_bye_friendly, d_bye_hostile;
}