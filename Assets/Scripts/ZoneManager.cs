using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    public int EnemyCount
    {
        get { return enemies.Count; }
    }

    private void Start()
    {
        // Agrega aqu� la l�gica para agregar las referencias de los enemigos a la lista
    }

    private void Update()
    {
        // Verifica si la lista de enemigos est� vac�a
        if (enemies.Count == 0)
        {
            // Todos los enemigos han sido eliminados, as� que destruye el objeto de la zona
            Destroy(gameObject);
        }
    }

    // Agrega este m�todo para que los enemigos puedan notificar su eliminaci�n
    public void RemoveEnemy(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }
}
