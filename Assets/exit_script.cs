using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class exit_script : MonoBehaviour, IinteractionTrigger
{
    public Button button;
    public TMP_Text text;

    public interactButton ib;

    /*public Animator playerAnimator;
    private bool setUpped = false;

    private void Update()
    {
        
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        button.gameObject.SetActive(true);
        text.SetText("Exit");
        ib.callback = this;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;
    }

    public AudioSource door;

    public void callback()
    {
        button.gameObject.SetActive(false);
        text.SetText("");
        ib.callback = null;

        if(globalVars.progress >= 5f)
        {
            ll.LoadLevelByName("Done");
            return;
        }

        if (globalVars.progress < 1 && dm != null)
        {
            dm.StartDialogue(d1);
            return;
        }
        else if(globalVars.progress < 2 && dm != null)
        {
            dm.StartDialogue(d2);
            return;
        }

        if(door != null)
            door.PlayOneShot(door.clip);

        //Debug.Log("exited");
        //dm.StartDialogue(dc);
        ll.LoadLevelByName("GameScene1");

        if(SceneManager.GetActiveScene().name == "home")
        {
            LevelLoader.startpos = new Vector2(4, -0.5f);
        }
        if (SceneManager.GetActiveScene().name == "doc")
        {
            LevelLoader.startpos = new Vector2(91, 20);
        }
        Debug.Log("exited");
    }
    
    public LevelLoader ll;

    public DialogueManager dm;
    public dialogue d1,     // before talking to mom
        d2;                 // before taking the money
}
