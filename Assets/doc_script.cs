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

    public static doc_script instance;

    private void Start()
    {
        instance = this;
    }

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
            if (globalVars.MCx_level == 2 && hudscipt.instance.mone.text == "15")
                dm.StartDialogue(dc_high_mcx_15m);
            else if (globalVars.MCx_level == 2)
                dm.StartDialogue(dc_high_mcx_10m);
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

    public void got_threatened()
    {
        //dm.StartDialogue(result_threaten, true);
        dm.nextDialogue = result_threaten;
    }

    public void got_robbed()
    {
        //dm.StartDialogue(result_steal, true);
        dm.nextDialogue = result_steal;
    }

    public void pleaded()
    {
        dm.nextDialogue = result_plea;
    }

    public void bought()
    {
        dm.nextDialogue = result_buy;
    }

    public DialogueManager dm;

    public dialogue_choices dc_high_mcx_15m, dc_high_mcx_10m, dc_low_mcx;
    public dialogue result_threaten, result_steal, result_buy, result_plea;
    public dialogue d_bye_friendly, d_bye_hostile;
}