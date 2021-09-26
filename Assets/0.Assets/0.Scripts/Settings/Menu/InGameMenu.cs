using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;

    [SerializeField] private GameObject InGameMenuPanel;


    private void Awake()
    {
        InGameMenuPanel.SetActive(false);
    }

    public void OnPressInGameMenu()
    {
        if(IsGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        InGameMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void ResumeGame()
    {
        InGameMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;

    }

    public void OnGotoMenuScene()
    {
        Time.timeScale = 1f;
        IsGamePaused = false;


    }

    public void OnQuit()
    {
        Application.Quit();
    }

}
