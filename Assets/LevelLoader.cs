using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static Vector2 startpos;

    public Animator transition;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelIndex);

    }

    public void LoadLevelByName(string name)
    {
        StartCoroutine(LoadLevel(name));
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelName);
    }

}
