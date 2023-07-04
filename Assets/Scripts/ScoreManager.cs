using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private float score;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        textMesh.text = score.ToString("0");
    }
}
