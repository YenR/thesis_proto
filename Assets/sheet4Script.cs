using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheet4Script : MonoBehaviour
{
    public LevelLoader ll;

    public networkScript network;

    private void Start()
    {

        if (network != null)
            network.OnPress();
    }

    public void onPressContinue()
    {

       // if (globalVars.data == null)
       //     globalVars.data = new collectedData();
        globalVars.data.start_game = Time.time;
        ll.LoadNextLevel();

    }
}
