using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheet4Script : MonoBehaviour
{
    public LevelLoader ll;

    public void onPressContinue()
    {
        globalVars.data.start_game = Time.time;
        ll.LoadNextLevel();
    }
}
