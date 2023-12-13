using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public string sceneName;
    public GameObject settingWindow;
    public bool isPaused;

    private void Awake()
    {
        if (settingWindow == null)
            return;
        else
            settingWindow.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        settingWindow.SetActive(false);
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        settingWindow.SetActive(true);
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnclickResumeButton()
    {
        Resume();
    }

    public void OnClickPauseButton()
    {
        Pause();
    }
}
