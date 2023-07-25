using UnityEngine;
using TMPro;

public class DeactivateOnScore : MonoBehaviour
{
    public int minScoreRequired = 100; // Cantidad m�nima de score requerida para desactivar el objeto
    public ScoreManager scoreManager; // Referencia al componente ScoreManager del jugador
    public TextMeshProUGUI requiredScoreText; // Referencia al objeto de texto para mostrar el mensaje

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (scoreManager.score >= minScoreRequired)
            {
                // El jugador tiene la cantidad m�nima de score requerida, desactivar el objeto
                gameObject.SetActive(false);
            }
            else
            {
                // El jugador no tiene la cantidad m�nima de score requerida, mostrar mensaje
                if (requiredScoreText != null)
                {
                    requiredScoreText.text = "Score requerido: " + minScoreRequired.ToString();
                }
            }
        }
    }
}
