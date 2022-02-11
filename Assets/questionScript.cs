using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionScript : MonoBehaviour
{
    public int qid;
    public ToggleGroup toggleGroup;
    public Toggle[] toggles;
    public int[] togglevalues;

    public int get_answer()
    {
        if (!toggleGroup.AnyTogglesOn())
            return int.MinValue;

        Toggle active = null;
        foreach (Toggle t in toggleGroup.ActiveToggles())
        {
            active = t;
            break;
        }

        for (int i=0; i<toggles.Length; i++)
        {
            if (active == toggles[i])
                return togglevalues[i];
        }

        return int.MaxValue;
        
    }
}
