using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        // Recupera el puntaje guardado al cargar el nivel
        score = PlayerPrefs.GetInt("Puntaje", 0);

        textMesh = GetComponent<TextMeshProUGUI>();
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;

        // Guarda el puntaje actualizado
        PlayerPrefs.SetInt("Puntaje", score);
        PlayerPrefs.Save();

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        textMesh.text = score.ToString("0");
    }
}
