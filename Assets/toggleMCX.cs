using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleMCX : MonoBehaviour
{
    public Toggle tog;
    
    public void onToggle()
    {
        if (tog.isOn)
            globalVars.MCx_level = 2;
        else
            globalVars.MCx_level = 1;
    }
}
