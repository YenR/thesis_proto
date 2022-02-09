using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVars //: MonoBehaviour
{
    public static float progress = 0f;

    // 0 - need to talk to mom
    // 1 - need to get money
    // 2 - need to talk to bandits
    // 3 - need to go to doctor
    // 3.1 - need to enter doctors house
    // 4 - need to go back to mom
    // 5 - done
    

    // MCx level 1 = low moral complexity
    // MCx level 2 = high moral complexity
    public static int MCx_level = 1;

    public static collectedData data;
}
