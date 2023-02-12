using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndGameScript : MonoBehaviour
{
  

    public void startGameFunc()
    {
        TimeScript.theTime = 0.0f;
        CoinScript.collectablesCollected = 0;
        TrapScript.currentHealth = 100;
        FindObjectOfType<AudioManager>().PlayMethod("Button Sound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().QuitMethod("Main Menu Soundtrack");
        FindObjectOfType<AudioManager>().PlayMethod("PlayerTheme");
    }

    public void endGameFunc()
    {
        TimeScript.theTime = 0.0f;
        FindObjectOfType<AudioManager>().PlayMethod("Button Sound");
        SceneManager.LoadScene(0);
    }

    public void QuitGameFunc()
    {
        Application.Quit();
    }
}
