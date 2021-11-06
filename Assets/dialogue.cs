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

        if(result == 1 ) // took 10 coins
        {
            hudscipt.instance.update_money("10");
        }
        if(result == 2) // took 15 coins
        {
            hudscipt.instance.update_money("15");
            //hudscipt.instance.update_todo("Talk to the doctor.\nHe lives on the other side of the forest.");
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

        if(result == 10) // threaten the doctor to give it for free
        {
            doc_script.friendly = false;
            doc_script.instance.got_threatened();
        }

        if (result == 11) // threaten the doctor to give it for 10
        {
            doc_script.friendly = false;
            if (hudscipt.instance.mone.text == "15")
                hudscipt.instance.update_money("5");
            else
                hudscipt.instance.update_money("0");
            doc_script.instance.got_threatened();
        }

        if (result == 12) // steal the medicine
        {
            doc_script.friendly = true;
            doc_script.instance.got_robbed();
        }
    }
}
