using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactButton : MonoBehaviour
{
    public IinteractionTrigger callback = null;

    public void onClick()
    {
        Debug.Log("clicked");

        if (callback != null)
        {
            callback.callback();
            Debug.Log("callbacked");
            callback = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && callback != null)
        {
            callback.callback();
        }
        
    }
}
