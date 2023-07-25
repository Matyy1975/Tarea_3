using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// En alg�n otro script que detecta la destrucci�n del enemigo
public class CombatManager : MonoBehaviour
{
    public EnemyShooting enemy1;
    public EnemyShooting enemy2;
    // Puedes agregar referencias a m�s enemigos si es necesario

    // L�gica para detectar que un enemigo ha sido destruido
    //...

    public void EnemyDestroyed(EnemyShooting enemy)
    {
        // Llama al m�todo para destruir al enemigo con animaci�n
        enemy.DestroyEnemyWithAnimation();
    }
}
