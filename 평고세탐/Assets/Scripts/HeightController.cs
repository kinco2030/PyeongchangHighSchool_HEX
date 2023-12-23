using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightController : MonoBehaviour
{
    [SerializeField] private Text heightText;
    [SerializeField] private GameObject target;

    private Vector3 targetPos;

    private void Awake()
    {
        targetPos = target.transform.position;
    }

    private void Update()
    {
        heightText.text = "≥Ù¿Ã : " + (Mathf.Round(targetPos.y) + 2).ToString() + "M";
        targetPos = target.transform.position;
        GameManager.Instance.height = targetPos.y;
    }
}
