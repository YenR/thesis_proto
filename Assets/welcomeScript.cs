using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;
using System;

public class welcomeScript : MonoBehaviour
{
    public Toggle t1, t2, t3;
    public TMP_InputField inputfield;

    public TMP_Text errortext;

    public TMP_InputField country, age;
    public Toggle g1, g2, g3;

    public int step = 0;

    // Start is called before the first frame update
    void Start()
    {
        globalVars.data = new collectedData();
        globalVars.data.starttime = Time.time;
    }

    public WebGLSupport.WebGLInput w1, w2, w3;

    public void onPressContinue()
    {
        if(step==0)
        {
            if (!t1.isOn || !t2.isOn)
            {
                errortext.SetText("Please accept the terms and conditions as well as the notice about data regulations.");
                return;
            }
        }
        else if(step == 1)
        {
            if (country.text == string.Empty)
            {
                errortext.SetText("Please enter a valid country.");
                return;
            }
            if (age.text == string.Empty || !int.TryParse(age.text, out int n))
            {
                errortext.SetText("Please enter a valid age.");
                return;
            }
            if (!g1.isOn && !g2.isOn && !g3.isOn)
            {
                errortext.SetText("Please select what gender you identify as.");
                return;
            }
            if (t3.isOn)
            {
                if (inputfield.text == string.Empty || !TestEmail.IsEmail(inputfield.text))
                {
                    errortext.SetText("Please put in a valid e-mail address if you want to take part in the raffle.");
                    return;
                }
            }

            if (t3.isOn)
                globalVars.data.enter_draw = true;
            else
                globalVars.data.enter_draw = false;
            
            globalVars.data.email = inputfield.text;

            globalVars.data.country = country.text;
            globalVars.data.age = int.Parse(age.text);
            if (g1.isOn)
                globalVars.data.gender = 0;
            else if (g2.isOn)
                globalVars.data.gender = 1;
            else if (g3.isOn)
                globalVars.data.gender = 2;
            else
                globalVars.data.gender = int.MinValue;
        }
        else
        {
            return;
        }
        
        
        ll.LoadNextLevel();
    }

    public LevelLoader ll;
    public networkScript ns;

    // from https://forum.unity.com/threads/check-if-its-an-e-mail.73132/
    public static class TestEmail
    {
        /// <summary>
        /// Regular expression, which is used to validate an E-Mail address.
        /// </summary>
        public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


        /// <summary>
        /// Checks whether the given Email-Parameter is a valid E-Mail address.
        /// </summary>
        /// <param name="email">Parameter-string that contains an E-Mail address.</param>
        /// <returns>True, wenn Parameter-string is not null and contains a valid E-Mail address;
        /// otherwise false.</returns>
        public static bool IsEmail(string email)
        {
            if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
            else return false;
        }
    }
}
