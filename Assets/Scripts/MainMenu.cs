using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void StartGame()
    {
        // StartCoroutine(StartGameWait());
        levelLoader.FadeToNextLevel();
    }

    // IEnumerator StartGameWait()
    // {
    //     yield return new WaitForSeconds(1);
    //     SceneManager.LoadScene("Main");
    // }
}
