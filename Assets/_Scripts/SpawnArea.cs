using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public Vector2 min;
    public Vector2 max;

    void Start()
    {
        // Pega todos os walls com tag "Wall"
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wall in walls)
        {
            Collider2D col = wall.GetComponent<Collider2D>();
            if (col != null)
            {
                Bounds b = col.bounds;
                min = new Vector2(Mathf.Min(min.x, b.min.x), Mathf.Min(min.y, b.min.y));
                max = new Vector2(Mathf.Max(max.x, b.max.x), Mathf.Max(max.y, b.max.y));
            }
        }

        // Adiciona uma margem interna pra evitar spawn colado na parede
        min += Vector2.one * 1.1f;
        max -= Vector2.one * 1.1f;
    }
}
