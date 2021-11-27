using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thinkingScript : MonoBehaviour
{
    public GameObject player_thoughts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hudscipt.money == "15")
            player_thoughts.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player_thoughts.SetActive(false);
    }
}
