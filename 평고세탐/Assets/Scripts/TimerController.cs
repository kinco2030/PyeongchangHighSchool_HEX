using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    float setTime;
    private void Awake()
    {
        setTime = GameManager.Instance.setTime;
        timerText.text = setTime.ToString();
    }

    private void Update()
    {
        if (setTime > 0)
        {
            setTime -= Time.deltaTime;
        }
        else if (setTime <= 0)
        {
            timerText.text = "е╦юс ╬ф©Т!";
            GameManager.Instance.gameover = true;
            Time.timeScale = 0;
        }

        timerText.text = Mathf.Round(setTime).ToString();
    }
}
