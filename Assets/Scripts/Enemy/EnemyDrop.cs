using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab del item a generar
    public float dropChance = 0.5f; // Probabilidad de aparición del item (0.0 a 1.0)

    private void OnDestroy()
    {
        if (Random.value <= dropChance)
        {
            // Generar el item si se cumple la probabilidad
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }
}
