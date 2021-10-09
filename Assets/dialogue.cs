using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class dialogue
{
    public string name;
    [TextArea(3,10)]
    public string[] sentences;
}

[System.Serializable]
public class dialogue_choices : dialogue
{
    [TextArea(3, 10)]
    public string[] choices;
    public int[] choice_results;
}

public class dialogue_result
{
    public static void handle_result(int result)
    {
        Debug.Log("got result: " + result);

        if(result == 1 || result == 2)
        {
            hudscipt.instance.update_todo("Talk to the doctor.\nHe lives on the other side of the forest.");
        }
        if(result == 3)
        {
            hudscipt.instance.update_todo("Return to mom.");
        }
        if(result == 5) // fight the bandits
        {
            bandit_script.instance.fight();
        }
        if(result == 6) // deceive the bandits
        {
            bandit_script.instance.moveAway();
        }
    }
}
