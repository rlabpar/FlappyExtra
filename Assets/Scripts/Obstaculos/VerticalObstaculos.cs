using UnityEngine;

public class VerticalObstaculos : MonoBehaviour
{
    public float velocidadVertical = 3f;
    public float amplitud = 2f;

    private float posYInicial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posYInicial = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Si es GameOver volvemos
        if (GameManager.Instance.isGameOver) return;

        // Calculamos la nueva posición Y usando la función seno
        float nuevaY = posYInicial + Mathf.Sin(Time.time * velocidadVertical) * amplitud;

        // Actualizamos la posición manteniendo la X y la Z intactas
        transform.position = new Vector3(transform.position.x, nuevaY, transform.position.z);
    }
}
