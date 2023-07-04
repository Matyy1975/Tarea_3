using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    private int score=0;
    private TextMeshProUGUI textMesh;

    public void AddScore(int points)
    {
        score += points;
    }

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        textMesh.text = score.ToString("0");
    }

}
