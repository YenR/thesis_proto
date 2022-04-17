using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banditThinking : MonoBehaviour
{
    public GameObject player_thoughts;
    public bool onlyOnce = true;

    private bool done = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("thinkin of bandits1");
        if (onlyOnce && done)
            return;

        //Debug.Log("thinkin of bandits2" + bandit_script.state + globalVars.progress);
        if (bandit_script.state == 1 && globalVars.progress >= 3f && globalVars.MCx_level == 2) //hudscipt.money == "15")
        {
            //Debug.Log("thinkin of bandits");
            player_thoughts.SetActive(true);
            done = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player_thoughts.SetActive(false);
    }
}
