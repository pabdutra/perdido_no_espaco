using UnityEngine;

public class ColetavelMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 direction;
    private Rigidbody2D rb;

    private float minX, maxX, minY, maxY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = GetRandomDirection();
        CalculateMapBounds();
    }

    void Update()
    {
        Vector2 newPosition = rb.position + direction * moveSpeed * Time.deltaTime;

        if (newPosition.x < minX || newPosition.x > maxX)
        {
            direction.x *= -1;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        }

        if (newPosition.y < minY || newPosition.y > maxY)
        {
            direction.y *= -1;
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        }

        rb.MovePosition(newPosition);
    }

    Vector2 GetRandomDirection()
    {
        return Random.insideUnitCircle.normalized;
    }

    void CalculateMapBounds()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

        if (walls.Length == 0)
        {
            Debug.LogWarning("Nenhuma parede com tag 'Wall' foi encontrada!");
            return;
        }

        Bounds bounds = walls[0].GetComponent<Collider2D>().bounds;

        foreach (GameObject wall in walls)
        {
            bounds.Encapsulate(wall.GetComponent<Collider2D>().bounds);
        }

        float margin = 1.1f;

        minX = bounds.min.x + margin;
        maxX = bounds.max.x - margin;
        minY = bounds.min.y + margin;
        maxY = bounds.max.y - margin;
    }
}
