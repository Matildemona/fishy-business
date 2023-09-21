using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public bool isPaused = false;
    [SerializeField] AudioManager audioManager;
    [SerializeField] GameObject settingsCanvas;
    [SerializeField] GameObject titlescreenCanvas;
    [SerializeField] GameObject creditsCanvas;
    [SerializeField] CountDownStart countDownStart;
    [SerializeField] GameObject tutorialCanvas;

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
        AudioManager.Instance.PlaySFX(AudioManager.Instance.clickSFX);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(countDownStart.CountDownCanvas());
    }

    public void LoadLevel2()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.clickSFX);
        SceneManager.LoadScene(2);
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlayMusic(AudioManager.Instance.bGMusic2);
        StartCoroutine(countDownStart.CountDownCanvas());
    }

    public void LoadLevel3()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.clickSFX);
        SceneManager.LoadScene(3);
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlayMusic(AudioManager.Instance.bGMusic3);
        StartCoroutine(countDownStart.CountDownCanvas());
    }
    public void PlayGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.clickSFX);
        AudioManager.Instance.PlayMusic(AudioManager.Instance.bGMusic1);
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX(audioManager.clickSFX);
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void GoToMenu()
    {
        AudioManager.Instance.PlaySFX(audioManager.clickSFX);
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlayMusic(AudioManager.Instance.tLMusic);
        SceneManager.LoadScene(0);
    }

    public void FromSettingsToMenu()
    {
        AudioManager.Instance.PlaySFX(audioManager.clickSFX);
        settingsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        titlescreenCanvas.SetActive(true);
    }

    public void LoadSettings()
    {
        AudioManager.Instance.PlaySFX(audioManager.clickSFX);
        titlescreenCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void TutorialContinue()
    {
        AudioManager.Instance.PlaySFX(audioManager.clickSFX);
        Time.timeScale = 1;
        tutorialCanvas.SetActive(false);
    }

    public void LoadCredits()
    {
        AudioManager.Instance.PlaySFX(audioManager.clickSFX);
        titlescreenCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

}

