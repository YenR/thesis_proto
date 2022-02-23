using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        int mcx = Random.Range(1, 3);
        Debug.Log("got mcx level: " + mcx);
        globalVars.MCx_level = mcx;
        globalVars.data.mcx_lvl = mcx;
    }

    public void PlayGame()
    {
        Debug.Log("start game");
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
    
}
