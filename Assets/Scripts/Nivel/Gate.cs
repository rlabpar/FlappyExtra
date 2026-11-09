using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance.isGameOver) return;
    }

    private void OnTriggerEnter2D(Collider2D gate)
    {
        if (gate.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level2");
        }

        Debug.Log("Vamos al nivel 2");
    }
}
