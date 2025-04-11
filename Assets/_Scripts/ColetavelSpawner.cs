using UnityEngine;

public class ColetavelSpawner : MonoBehaviour
{
    public GameObject coletavelPrefab;
    private static ColetavelSpawner instance;
    private SpawnArea area;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        area = Object.FindFirstObjectByType<SpawnArea>();
        SpawnColetavel();
    }

    public static void SpawnColetavel()
    {
        if (instance == null || instance.coletavelPrefab == null || instance.area == null) return;

        Vector2 pos = new Vector2(
            Random.Range(instance.area.min.x, instance.area.max.x),
            Random.Range(instance.area.min.y, instance.area.max.y)
        );

        Instantiate(instance.coletavelPrefab, pos, Quaternion.identity);
    }
}
