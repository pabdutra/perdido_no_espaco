using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private static EnemySpawner instance;
    private SpawnArea area;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        area = Object.FindFirstObjectByType<SpawnArea>();
        SpawnEnemy(); // Spawna o primeiro inimigo no início
    }

    public static void SpawnEnemy()
    {
        if (instance == null || instance.enemyPrefab == null || instance.area == null) return;

        Vector2 pos = new Vector2(
            Random.Range(instance.area.min.x, instance.area.max.x),
            Random.Range(instance.area.min.y, instance.area.max.y)
        );

        Instantiate(instance.enemyPrefab, pos, Quaternion.identity);
    }
}
