using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class agreementclick : MonoBehaviour
{
    public Toggle[] t = new Toggle[3];

    public void onClick(int i)
    {
        t[i].isOn = !t[i].isOn;
    }
}
