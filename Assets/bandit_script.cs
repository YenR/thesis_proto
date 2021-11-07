using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bandit_script : MonoBehaviour
{
    public static bool talked_to = false;
    public static int state = 0;
    // 0 = default
    // 1 = fought
    // 2 = threatened
    // 3 = gone (after running away)

    public static bandit_script instance;

    private void Start()
    {
        instance = this;
        if(state == 1)
        {
            bandits.SetBool("fought", true);
        }

        if (state == 2)
        {
            bandits.SetBool("made_way", true);
        }

        if(state == 3)
        {
            bandits.SetBool("gone", true);
        }
    }

    public dialogue deceived;

    public void moveAway()
    {
        dm.nextDialogue = deceived;

        bandits.SetTrigger("make_way");
        state = 2;
        /*
        Debug.Log("moving");
        bboss.SetTrigger("make_way");
        b1.SetTrigger("make_way");
        b2.SetTrigger("make_way");*/
    }

    public Animator bandits, player;

    public void fight()
    {
        //player.SetTrigger("fight");
        bandits.SetTrigger("fight");
        state = 1;
    }

    //public Animator bboss, b1, b2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!talked_to)
        {
            dm.StartDialogue(d);
            if (globalVars.MCx_level == 1)
                dm.nextDialogue = dc;
            else
                dm.nextDialogue = dc_4;
            talked_to = true;
            globalVars.progress = 3;
        }
    }
    

    public void callback()
    {
        Debug.Log("talked to bandits");
        dm.StartDialogue(dc);
    }

    public DialogueManager dm;
    public dialogue d;              // intro for both versions
    public dialogue_choices dc;     // MCx 1 version
    public dialogue_choices dc_4;   // MCx 2 version

    public dialogue convinced;
    public dialogue running_away;

    public playerMovement p;

    public void runaway()
    {
        //bandits.SetTrigger("make_way");
        dm.nextDialogue = running_away;
        p.run();
        state = 3;  
    }

    public void convince()
    {
        dm.nextDialogue = convinced;

        bandits.SetTrigger("make_way");
        state = 2;
    }
}
