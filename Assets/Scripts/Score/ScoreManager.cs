using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

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
