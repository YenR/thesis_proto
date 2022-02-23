using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;
//using System.Net.NetworkInformation;


public class networkScript : MonoBehaviour
{
    public TMP_InputField input;
    public TMP_Text output;

    string postURL = "https://mcx-aau.at/post-json.php";
        // "http://hosting169269.ae858.netcup.net/testing/post-json.php";
        //"http://127.0.0.1/testing/post.php";

    public void OnPress()
    {
        //Debug.Log(GetNetworkInterfaces());
        collectedData sendme = globalVars.data; //new collectedData();
        sendme.mac_ad = "";// GetNetworkInterfaces();
        sendme.endtime = Time.time;
        sendme.onMobile = Application.isMobilePlatform;
        //sendme.message = input.text;
        StartCoroutine(SendPostRequest(sendme));
    }

    IEnumerator SendPostRequest(collectedData post)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("data", JsonUtility.ToJson(post)));

        Debug.Log("built form");

        UnityWebRequest www = UnityWebRequest.Post(postURL, wwwForm);

        yield return www.SendWebRequest();

        //Debug.Log("form sent: " + JsonUtility.ToJson(post));

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log("showing errors");
            Debug.LogError(www.error);

            if (callback != null)
            {
                callback.callMeBack(false, www.error);
            }
        }
        else
        {
            Debug.Log("success");
            Debug.Log(www.downloadHandler.text);


            if (callback != null)
            {
                callback.callMeBack(true, www.downloadHandler.text);
            }
        }

    }

    public sheet5script callback = null;

    /*
    public string GetNetworkInterfaces()
    {
        try
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string info = "";

            foreach (NetworkInterface adapter in nics)
            {
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                string mac = null;
                for (int i = 0; i < bytes.Length; i++)
                {
                    mac = string.Concat(mac + (string.Format("{0}", bytes[i].ToString("X2"))));
                    if (i != bytes.Length - 1)
                    {
                        mac = string.Concat(mac + "-");
                    }
                }
                info += mac + " ";

                //info += "ip: \n" + adapter.GetIPProperties.ToString() + "\n";
            }
            return info;

        }
        catch(Exception e)
        {
            return "mac address could not be determined";
        }
    }*/

}
