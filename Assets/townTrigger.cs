using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggered town" + globalVars.progress);
        if(globalVars.progress == 3f)
        {
            globalVars.progress = 3.1f;

            hudscipt.instance.update_todo("Enter the doctor's office and buy medicine.");
        }
    }
}
