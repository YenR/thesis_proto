using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class interactThink : interactionTrigger
{
    public string thought;
    public GameObject playerThoughts;
    public TMP_Text thought_txt;

    override public void callback()
    {
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;

        thought_txt.SetText(thought);
        playerThoughts.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;
        playerThoughts.SetActive(false);
    }

}
