using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void OpenIntro()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Setting");
    }

    public void BackToMenu()
    {
        Debug.Log("Back button pressed");
        SceneManager.LoadScene("MainMenu");
    }
    
}
