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

        if (globalVars.progress < 1)
        {
            dm.StartDialogue(d1);
            return;
        }
        else if(globalVars.progress < 2)
        {
            dm.StartDialogue(d2);
            return;
        }

        Debug.Log("exited");
        //dm.StartDialogue(dc);
        ll.LoadLevelByName("GameScene1");

        if(SceneManager.GetActiveScene().name == "home")
        {
            LevelLoader.startpos = new Vector2(4, 0);
        }
        if (SceneManager.GetActiveScene().name == "doc")
        {
            LevelLoader.startpos = new Vector2(91, 20);
        }
    }
    
    public LevelLoader ll;

    public DialogueManager dm;
    public dialogue d1,     // before talking to mom
        d2;                 // before taking the money
}
