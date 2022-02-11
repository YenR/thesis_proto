using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sheet2Script : MonoBehaviour
{
    public questionScript[] q;
    public TMP_Text errortext;
    public LevelLoader ll;

    public void onClickContinue()
    {
        foreach(questionScript qs in q)
        {
            Debug.Log(qs.qid + ": " + qs.get_answer());

            if(qs.get_answer() == int.MaxValue || qs.get_answer() == int.MinValue)
            {
                errortext.SetText("Please answer all questions before continuing.");
                return;
            }

           globalVars.data.answers_mct[qs.qid - 1] = qs.get_answer();
        }

        ll.LoadNextLevel();
    }
}
