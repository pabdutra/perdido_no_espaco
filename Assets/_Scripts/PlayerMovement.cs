using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource som;
    public float speed;

    private Vector2 minSpawn;
    private Vector2 maxSpawn;

    private Cronometro cronometro;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        som = GetComponent<AudioSource>();

        // Busca limites do SpawnArea
        SpawnArea area = Object.FindFirstObjectByType<SpawnArea>();
        if (area != null)
        {
            minSpawn = area.min;
            maxSpawn = area.max;
        }

        cronometro = Object.FindFirstObjectByType<Cronometro>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coletavel"))
        {
            som.Play();
            GameController.Collect();
            Destroy(other.gameObject);

            if (cronometro != null)
            {
                cronometro.AdicionarTempo(1f);
            }
        }
    }
}
