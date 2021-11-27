using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetScript : MonoBehaviour
{
    public void resetStatics()
    {
        globalVars.progress = 0f;
        globalVars.MCx_level = 1;
        hudscipt.money = "0";
        hudscipt.text = "Talk to mom";
        bandit_script.talked_to = false;
        bandit_script.state = 0;
        doc_script.friendly = true;
    }
}
