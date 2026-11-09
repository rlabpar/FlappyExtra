using UnityEngine;

public class TechoVerticalObstaculos : MonoBehaviour
{
    public float velocidadVertical = 2f;

    private bool activarMovimiento = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si es GameOver volvemos
        if (GameManager.Instance.isGameOver) return;

        if (!activarMovimiento) return;

        // Calculamos la nueva posición Y usando la función seno
        transform.Translate(Vector3.down * velocidadVertical * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activarMovimiento = true;
        }
    }
}
