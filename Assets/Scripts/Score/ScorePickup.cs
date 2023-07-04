using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public int scoreAmount = 10; // Puntos a agregar al score

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obtener referencia al ScoreManager
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

            if (scoreManager != null)
            {
                // Agregar puntos al score
                scoreManager.AddScore(scoreAmount);

                // Destruir el objeto de recolección de puntos
                Destroy(gameObject);
            }
        }
    }
}
