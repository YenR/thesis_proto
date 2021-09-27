using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bandit_script : MonoBehaviour
{
    public static bool talked_to = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!talked_to)
        {
            dm.StartChoiceDialogue(dc);
            talked_to = true;
        }
    }
    

    public void callback()
    {
        Debug.Log("talked to bandits");
        dm.StartDialogue(dc);
    }

    public DialogueManager dm;
    public dialogue_choices dc;
}
