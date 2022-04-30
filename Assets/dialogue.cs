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
        //Debug.Log("got result: " + result);

        if(result == 1 ) // took 10 coins
        {
            hudscipt.instance.update_money("10");
            if (globalVars.data != null)
                globalVars.data.answers_ingame[0] = 0;
        }
        if(result == 2) // took 15 coins
        {
            hudscipt.instance.update_money("15");
            //hudscipt.instance.update_todo("Talk to the doctor.\nHe lives on the other side of the forest.");
            if (globalVars.data != null)
                globalVars.data.answers_ingame[0] = 1;
        }
        if(result == 3)
        {
            hudscipt.instance.update_todo("Return to mom.");
        }
        if(result == 5) // fight the bandits
        {
            bandit_script.instance.fight();
            if (globalVars.data != null)
                globalVars.data.answers_ingame[1] = 0;
        }
        if(result == 6) // deceive the bandits
        {
            bandit_script.instance.moveAway();
            if (globalVars.data != null)
                globalVars.data.answers_ingame[1] = 1;
        }
        if(result == 7) // flee from bandits
        {
            bandit_script.instance.runaway();
            if (globalVars.data != null)
                globalVars.data.answers_ingame[1] = 2;
        }
        if(result == 8) // convince the bandits
        {
            bandit_script.instance.convince();
            if (globalVars.data != null)
                globalVars.data.answers_ingame[1] = 3;
        }

        if(result == 10) // threaten the doctor to give it for free
        {
            doc_script.friendly = false;
            doc_script.instance.got_threatened();
            if (globalVars.data != null)
                globalVars.data.answers_ingame[2] = 0;
        }

        if (result == 11) // threaten the doctor to give it for 10
        {
            doc_script.friendly = false;
            if (hudscipt.instance.mone.text == "15")
                hudscipt.instance.update_money("5");
            else
                hudscipt.instance.update_money("0");
            doc_script.instance.got_threatened();
            if (globalVars.data != null)
                globalVars.data.answers_ingame[2] = 1;
        }

        if (result == 12) // steal the medicine
        {
            doc_script.friendly = true;
            doc_script.instance.got_robbed();
            if (globalVars.data != null)
                globalVars.data.answers_ingame[2] = 2;
        }

        if(result == 13) // plea for better price
        {
            doc_script.friendly = true;
            if (hudscipt.instance.mone.text == "15")
                hudscipt.instance.update_money("5");
            else
                hudscipt.instance.update_money("0");
            doc_script.instance.pleaded();
            if(globalVars.data != null)
                globalVars.data.answers_ingame[2] = 3;
        }

        if(result == 14) // bought the medicine
        {
            doc_script.friendly = true;
            hudscipt.instance.update_money("0");
            doc_script.instance.bought();
            if (globalVars.data != null)
                globalVars.data.answers_ingame[2] = 4;
        }

        if(result == 20) // keep the money
        {
            mom_script.instance.keep_money();
            if (globalVars.data != null)
                globalVars.data.answers_ingame[3] = 0;
        }
        if(result == 21) // give money back to mom
        {
            mom_script.instance.confess();
            hudscipt.instance.update_money("0");
            if (globalVars.data != null)
                globalVars.data.answers_ingame[3] = 1;
        }
    }
}
