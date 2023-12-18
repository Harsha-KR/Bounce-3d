using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void MainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SpawnManager._Instance.StartCoroutine("StartGameRoutine");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
        Time.timeScale = 1f;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
