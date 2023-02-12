using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePlayScript : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public Button pauseBTN;

    public GameObject deathScreenUI;

    public GameObject originalCanvasUI;

    void Update()
    {
        if(TrapScript.currentHealth == 0)
        {
            YouDiedMethod();
            FindObjectOfType<AudioManager>().PlayMethod("Death");
            TrapScript.currentHealth = 100;
        }
    }

    // The following two methods are for the pause and play images
    public void Resume()
    {
        FindObjectOfType<AudioManager>().PlayMethod("Button Sound");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseBTN.GetComponent<Image>().enabled = true;
    }

    public void Pause()
    {
        FindObjectOfType<AudioManager>().PlayMethod("Button Sound");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        pauseBTN.GetComponent<Image>().enabled = false;
    }

    public void RestartMethod()
    {
        TimeScript.theTime = 0.0f;
        FindObjectOfType<AudioManager>().PlayMethod("Button Sound");
        TrapScript.currentHealth = 100;
        CoinScript.collectablesCollected = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1");
        FindObjectOfType<AudioManager>().QuitMethod("PlayerTheme");
        FindObjectOfType<AudioManager>().PlayMethod("PlayerTheme");
    }

    public void QuitMethod()
    {
        TimeScript.theTime = 0.0f;
        FindObjectOfType<AudioManager>().PlayMethod("Button Sound");
        TrapScript.currentHealth = 100;
        CoinScript.collectablesCollected = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Scene");
        FindObjectOfType<AudioManager>().QuitMethod("PlayerTheme");
        FindObjectOfType<AudioManager>().PlayMethod("Main Menu Soundtrack");
    }

    public void YouDiedMethod()
    {
        pauseMenuUI.SetActive(false);
        originalCanvasUI.SetActive(false);
        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryMethod()
    {
        TimeScript.theTime = 0.0f;
        FindObjectOfType<AudioManager>().PlayMethod("Button Sound");
        TrapScript.currentHealth = 100;
        SceneManager.LoadScene("Level 1");
        originalCanvasUI.SetActive(true);
        deathScreenUI.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().QuitMethod("PlayerTheme");
        FindObjectOfType<AudioManager>().PlayMethod("PlayerTheme");
    }

    public void HomeMethod()
    {
        TimeScript.theTime = 0.0f;
        FindObjectOfType<AudioManager>().PlayMethod("Button Sound");
        TrapScript.currentHealth = 100;
        CoinScript.collectablesCollected = 0;
        SceneManager.LoadScene("Start Scene");
        deathScreenUI.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().QuitMethod("PlayerTheme");
        FindObjectOfType<AudioManager>().PlayMethod("Main Menu Soundtrack");
    }
}
