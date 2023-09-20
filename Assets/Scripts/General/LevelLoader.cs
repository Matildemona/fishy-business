using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public bool isPaused = false;
    [SerializeField] AudioManager audioManager;
    [SerializeField] Canvas settingsCanvas;
    [SerializeField] Canvas titlescreenCanvas;
    [SerializeField] CountDownStart countDownStart;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            pauseMenuCanvas.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            pauseMenuCanvas.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    public void LoadNextLevel()
    {
        audioManager.PlaySFX(audioManager.clickSFX);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(countDownStart.CountDownCanvas());
    }
    public void PlayGame()
    {
        audioManager.PlaySFX(audioManager.clickSFX);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.clickSFX);
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void GoToMenu()
    {
        audioManager.PlaySFX(audioManager.clickSFX);
        SceneManager.LoadScene(0);
    }

    public void FromSettingsToMenu()
    {
        audioManager.PlaySFX(audioManager.clickSFX);
        settingsCanvas.enabled = false;
        titlescreenCanvas.enabled = true;
    }

    public void LoadSettings()
    {
        audioManager.PlaySFX(audioManager.clickSFX);
        titlescreenCanvas.enabled = false;
        settingsCanvas.enabled = true;
    }

}

