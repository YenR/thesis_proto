using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bandit_script : MonoBehaviour
{
    public static bool talked_to = false;
    public static bandit_script instance;

    private void Start()
    {
        instance = this;
    }

    public void moveAway()
    {
        bandits.SetTrigger("make_way");
        /*
        Debug.Log("moving");
        bboss.SetTrigger("make_way");
        b1.SetTrigger("make_way");
        b2.SetTrigger("make_way");*/
    }

    public Animator bandits, player;

    public void fight()
    {
        player.SetTrigger("fight");
        bandits.SetTrigger("fight");
    }

    //public Animator bboss, b1, b2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!talked_to)
        {
            dm.StartDialogue(dc);
            talked_to = true;
        }
    }
    

    public void callback()
    {
        Debug.Log("talked to bandits");
        dm.StartDialogue(dc);
    }

    public DialogueManager dm;
    public dialogue_choices dc;     // MCx 1 version
    public dialogue_choices dc_4;   // MCx 2 version


}
