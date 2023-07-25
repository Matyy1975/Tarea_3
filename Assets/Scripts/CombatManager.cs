using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// En algún otro script que detecta la destrucción del enemigo
public class CombatManager : MonoBehaviour
{
    public EnemyShooting enemy1;
    public EnemyShooting enemy2;
    // Puedes agregar referencias a más enemigos si es necesario

    // Lógica para detectar que un enemigo ha sido destruido
    //...

    public void EnemyDestroyed(EnemyShooting enemy)
    {
        // Llama al método para destruir al enemigo con animación
        enemy.DestroyEnemyWithAnimation();
    }
}
