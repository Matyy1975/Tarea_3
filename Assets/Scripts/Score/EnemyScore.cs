using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    private ScoreManager scoreManager;
    public int enemyScore = 10; // Puntaje individual del enemigo
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void IncreaseScore()
    {
        scoreManager.AddScore(enemyScore);
    }
}
