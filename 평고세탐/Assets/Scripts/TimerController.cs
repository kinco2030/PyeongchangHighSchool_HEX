using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public float setTime = 120;

    private void Awake()
    {
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
            Debug.Log("е╦юс ╬ф©Т!");
        }

        timerText.text = Mathf.Round(setTime).ToString();
    }
}
