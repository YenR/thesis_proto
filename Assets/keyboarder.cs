using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboarder : MonoBehaviour
{
    public void showKB()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.EmailAddress);
    }

    public void hideKB()
    {
        //TouchScreenKeyboard.
    }
}
