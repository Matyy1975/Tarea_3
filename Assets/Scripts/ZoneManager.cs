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
        // Agrega aquí la lógica para agregar las referencias de los enemigos a la lista
    }

    private void Update()
    {
        // Verifica si la lista de enemigos está vacía
        if (enemies.Count == 0)
        {
            // Todos los enemigos han sido eliminados, así que destruye el objeto de la zona
            Destroy(gameObject);
        }
    }

    // Agrega este método para que los enemigos puedan notificar su eliminación
    public void RemoveEnemy(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }
}
