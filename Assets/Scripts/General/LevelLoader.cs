using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public bool isPaused = false;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    
}
