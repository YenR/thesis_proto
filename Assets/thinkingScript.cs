using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thinkingScript : MonoBehaviour
{
    public GameObject player_thoughts;
    public bool onlyOnce = true;

    private bool done = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onlyOnce && done)
            return;

        done = true;
        if(hudscipt.money == "15")
            player_thoughts.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player_thoughts.SetActive(false);
    }
}
