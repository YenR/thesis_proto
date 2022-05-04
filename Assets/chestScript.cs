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

    public static chestScript instance;

    private void Start()
    {
        instance = this;
    }

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
            chest.SetBool("open", true);
            chestOpen.PlayOneShot(chestOpen.clip);
            hudscipt.instance.update_todo("Go to the next town, on the other side of the forest.");
            dm.StartDialogue(dialog_mcx1);
            globalVars.progress = 2f;
            hudscipt.instance.update_money("10");

            playCoins(10, true);
        }
        else if (globalVars.progress == 1f && globalVars.MCx_level == 2)
        {
            chest.SetBool("open", true);
            chestOpen.PlayOneShot(chestOpen.clip);
            hudscipt.instance.update_todo("Go to the next town, on the other side of the forest.");
            dm.StartDialogue(dialog_mcx2);
            globalVars.progress = 2f;
        }
    }

    public void playCoins(int times, bool wait = false)
    {
        StartCoroutine(playCoinAnimation(times, wait));
    }

    public IEnumerator playCoinAnimation(int times, bool wait = false)
    {
        while(wait && !playerMovement.canMove) // wait for dialogue to close
        {
            yield return new WaitForSeconds(0.2f);
        }

        if (times <= 0)
        {
            yield return new WaitForSeconds(0.4f);
            chestOpen.PlayOneShot(chestOpen.clip);
            chest.SetBool("open", false);
            yield break;
        }

        coinBling.PlayOneShot(coinBling.clip);
        coin.SetTrigger("show");
        yield return new WaitForSeconds(0.3f);
        times--;
        StartCoroutine(playCoinAnimation(times));
    }

    public Animator coin, chest;
    public AudioSource coinBling, chestOpen;

    public DialogueManager dm;

    public dialogue dialog_mcx1;            // MCx 1 dialogue
    public dialogue_choices dialog_mcx2;    // MCx 2 dialogue
}
