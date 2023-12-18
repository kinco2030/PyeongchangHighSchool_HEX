using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightController : MonoBehaviour
{
    [SerializeField] private Text heightText;
    [SerializeField] private GameObject target;

    private Vector3 targetPos;
    private float max;

    private void Awake()
    {
        targetPos = target.transform.position;
        max = targetPos.y;
    }

    private void Update()
    {
        if (max <= targetPos.y)
            max = targetPos.y;

        heightText.text = "³ôÀÌ : " + Mathf.Round(max).ToString() + "M";
        targetPos = target.transform.position;
    }
}
