using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float ThrustForce = 350f;

    private bool muerto = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !muerto)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Debug.Log("Jumping!");
        
        rb.linearVelocity = Vector2.zero; // Velocidad a cero

        rb.AddRelativeForce(Vector2.up * ThrustForce); // Aplica una fueza hacia arriba
                            // Vector2.up --> Equivale a una direccion vertical positiva (0, 1)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (muerto) return; // Si estaba muerto volvemos para evitar que se ejecute varias veces si choca con varias cosas

        muerto = true;

        GameManager.Instance.GameOver(); // Llamamos a GameManager para terminar la partida

        // Frenamos el movimiento horizontal para que caiga recto hacia abajo
        rb.linearVelocity = Vector2.zero;
    }
}