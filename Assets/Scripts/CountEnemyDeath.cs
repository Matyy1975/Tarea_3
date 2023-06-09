using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountEnemyDeath : MonoBehaviour
{
    public UnityEvent onEnemiesDeath;
    public int currentDeaths = 0;
    public int maxDeaths = 1;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            currentDeaths += 1;
            if(currentDeaths >= maxDeaths)
            {
                onEnemiesDeath.Invoke();
            }
            else if (collision.tag == "Melee")
            {
                currentDeaths += 1;
                if (currentDeaths >= maxDeaths)
                {
                    onEnemiesDeath.Invoke();
                }
            }
        }
        
    }
}
