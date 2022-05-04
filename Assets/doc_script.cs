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
        dm.nextDialogue = result_threaten;

        StartCoroutine(getPotion());
    }


    public void got_forced()
    {
        dm.nextDialogue = result_threaten;

        StartCoroutine(giveCoins(1));
        StartCoroutine(getPotion());
    }

    public void got_robbed()
    {
        dm.nextDialogue = result_steal;
        StartCoroutine(stealPotion());
    }

    public void pleaded()
    {
        dm.nextDialogue = result_plea;
        StartCoroutine(giveCoins(1));
        StartCoroutine(getPotion());
    }

    public void bought()
    {
        dm.nextDialogue = result_buy;
        StartCoroutine(giveCoins(1));
        StartCoroutine(getPotion());
    }

    public IEnumerator stealPotion()
    {
        while(!playerMovement.canMove) // wait for dialogue to close
        {
            yield return new WaitForSeconds(0.2f);
        }
        docAnim.SetBool("look_away", true);
        potionAnim.SetTrigger("move");
        swipeAudio.PlayOneShot(swipeAudio.clip);
        yield return new WaitForSeconds(1.2f);
        docAnim.SetBool("look_away", false);
        //yield return 0;
    }

    public IEnumerator getPotion()
    {
        while (!playerMovement.canMove) // wait for dialogue to close
        {
            yield return new WaitForSeconds(0.2f);
        }

        potionAnim.SetTrigger("move");
        yield return new WaitForSeconds(0.2f);
        getAudio.PlayOneShot(getAudio.clip);
        //yield return 0;
    }

    public IEnumerator giveCoins(int amount)
    {
        if (amount <= 0)
        {
            //StartCoroutine(getPotion());
            //yield return new WaitForSeconds(0.2f);
            yield break;
        }

        while (!playerMovement.canMove) // wait for dialogue to close
        {
            yield return new WaitForSeconds(0.2f);
        }

        coinAnim.SetTrigger("show");
        coinAudio.PlayOneShot(coinAudio.clip);
        yield return new WaitForSeconds(0.33f);

        amount--;
        StartCoroutine(giveCoins(amount));
        yield return 0;
    }
    
    public DialogueManager dm;

    public dialogue_choices dc_high_mcx_15m, dc_high_mcx_10m, dc_low_mcx;
    public dialogue result_threaten, result_steal, result_buy, result_plea;
    public dialogue d_bye_friendly, d_bye_hostile;

    public Animator docAnim, potionAnim, coinAnim;
    public AudioSource coinAudio, swipeAudio, getAudio;
}