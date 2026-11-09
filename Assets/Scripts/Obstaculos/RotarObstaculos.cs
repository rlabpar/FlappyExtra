using UnityEngine;

public class RotarObstaculos : MonoBehaviour
{
    public float velocidadGiro = 50f;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver) return;

        // Rota el objeto sobre su propio eje Z (el plano 2D)
        transform.Rotate(0f, // Transform.Rotate(x,y,z) --> Rota el objeto
                         0f, // Dejamos X e Y = 0 pq en 2D solo rotamos en eje z
                         velocidadGiro * Time.deltaTime);
    }
}
