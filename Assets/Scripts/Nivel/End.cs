using UnityEngine;

public class End : MonoBehaviour
{

    public GameObject CanvasEnd;
    private bool nivelFinalizado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !nivelFinalizado)
        {
            nivelFinalizado = true;

            // Actualizamos el texto de la pantalla final con los puntos acumulados
            if (GameManager.Instance != null)
            {
                GameManager.Instance.MostrarEND();
            }

            if (CanvasEnd != null) {
                CanvasEnd.SetActive(true);
            }

            Time.timeScale = 0f;

            Debug.Log("¡Juego completado! Mostrando en pantalla End");
        }
    }
}
