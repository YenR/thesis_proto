using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheet4Script : MonoBehaviour
{
    public LevelLoader ll;

    public void onPressContinue()
    {

       // if (globalVars.data == null)
       //     globalVars.data = new collectedData();
        globalVars.data.start_game = Time.time;
        ll.LoadNextLevel();
    }
}
