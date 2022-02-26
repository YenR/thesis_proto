using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class sheet5script : MonoBehaviour
{
    public questionScript[] q;
    public TMP_Text errortext;
    public LevelLoader ll;

    public networkScript net;
    public Button continueButton;

    public TMP_InputField comments;

    private void Start()
    {
        if (globalVars.data == null)
            globalVars.data = new collectedData();
        globalVars.data.end_game = Time.time;
    }

    public void onClickContinue()
    {

        if (globalVars.data == null)
            globalVars.data = new collectedData();
        globalVars.data.endtime = Time.time;

        foreach (questionScript qs in q)
        {
            Debug.Log(qs.qid + ": " + qs.get_answer());

            if (qs.get_answer() == int.MaxValue || qs.get_answer() == int.MinValue)
            {
                errortext.SetText("Please answer all questions before continuing.");
                return;
            }

            globalVars.data.answers_guss[qs.qid] = qs.get_answer();
        }

        globalVars.data.comments = comments.text;

        //ll.LoadNextLevel();
        continueButton.interactable = false;
        net.callback = this;
        net.OnPress();

        errortext.SetText("Communicating with server. Please wait a second...");
    }

    public void callMeBack(bool success, string msg)
    {
        if(!success)
        {
            errortext.SetText("Something went wrong when recording your answers. Please try again in a few seconds.");
            continueButton.interactable = true;
            return;
        }

        ll.LoadNextLevel();
    }

}
