using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidad = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(-velocidad, 0f); // Velocidad de la componente Rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        // Si hay Game Over
        if(GameManager.Instance.isGameOver)
        {
            rb.linearVelocity = Vector2.zero; // No nos movemos
        }
    }
}
