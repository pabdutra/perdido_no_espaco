using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform jogador;
    public float speed = 3f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (jogador == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                jogador = playerObj.transform;
        }
    }

    void Update()
    {
        if (jogador == null || GameController.gameOverReal)
            return;

        Vector2 direction = (jogador.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.GameOverPorInimigo();
            Destroy(other.gameObject); // opcional: remove jogador da cena
        }
    }
}
