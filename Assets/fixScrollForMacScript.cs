using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fixScrollForMacScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.OSXPlayer || SystemInfo.operatingSystem.Contains("Mac OS X"))
        {
            ScrollRect sr = this.gameObject.GetComponent<ScrollRect>();
            if(sr)
            {
                sr.scrollSensitivity = 3;
            }
        }
    }
    
}
