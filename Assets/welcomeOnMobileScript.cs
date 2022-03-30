using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class welcomeOnMobileScript : MonoBehaviour
{
    public GameObject mobileWarning;
    public Animator crossfade;

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            mobileWarning.SetActive(true);
            //crossfade.SetTrigger("Start");
            
        }
    }
}
