using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hudscipt : MonoBehaviour
{
    public static hudscipt instance;

    public void show()
    {
        Debug.Log("showing");
        this.gameObject.SetActive(true);
    }

    public void hide()
    {
        Debug.Log("hiding");
        this.gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        if (text != null && text.Length > 0)
            update_todo(text);
        if (money != null && money.Length > 0)
            update_money(money);
    }

    public TMP_Text todo;
    public TMP_Text mone;

    public static string text;
    public static string money;// = "15";

    public void update_money(string m)
    {
        Debug.Log("updating money to "+ m);
        money = m;
        mone.SetText(m);
    }

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
