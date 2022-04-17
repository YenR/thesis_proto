using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IinteractionTrigger
{
    void callback();
}

public class interactionTrigger : MonoBehaviour, IinteractionTrigger
{
    public Button button;
    public TMP_Text text;
    public string buttonText = "Enter";
    public interactButton ib;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        button.gameObject.SetActive(true);
        text.SetText(buttonText);
        ib.callback = this;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;
    }

    public virtual void callback()
    {
        Debug.Log("entered");
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;

        //dm.StartDialogue(dc);
        ll.LoadLevelByName("home");
    }

    public DialogueManager dm;
    public dialogue_choices dc;
    public LevelLoader ll;
}
