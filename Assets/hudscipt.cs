using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hudscipt : MonoBehaviour
{
    public static hudscipt instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        if (text != null && text.Length > 0)
            update_todo(text);
    }

    public TMP_Text todo;

    public static string text;

    public void update_todo(string txt)
    {
        if(txt == null)
        {
            todo.SetText("");
            this.gameObject.SetActive(false);
            text = txt;
        }
        else
        {
            this.gameObject.SetActive(true);
            todo.SetText(txt);
            text = txt;
        }
    }
}
