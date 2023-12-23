using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject resultView;
    public TextMeshProUGUI heightText;

    private void Awake()
    {
        CheckResultView();
    }

    private void Update()
    {
        if (GameManager.Instance.gameover == true)
        {
            resultView.SetActive(true);
            heightText.text = "Best Score : " + (Mathf.Round(GameManager.Instance.height)+2).ToString() + "M";
        }
        else
        {
            resultView.SetActive(false);
        }
    }

    private void CheckResultView()
    {
        if (resultView == null)
            return;
        else
            resultView.SetActive(false);
    }
}