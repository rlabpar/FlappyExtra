using UnityEngine;

public class Coin : MonoBehaviour
{

    private Rigidbody2D rb;

    public float velocidad = 3f;
    public float amplitud = 0.5f;
    private float posYInicial;

    private bool recogido = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posYInicial = transform.position.y;
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float nuevaY = posYInicial + Mathf.Sin(Time.time * velocidad) * amplitud;

        transform.position = new Vector2(transform.position.x, nuevaY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !recogido)
        {
            recogido = true;

            GameManager.Instance.SumarPuntos(1);

            Debug.Log("¡Moneda recogida! +1 punto");

            // Destruimos para que desaparezca la moneda
            Destroy(gameObject);
        }
    }
}
