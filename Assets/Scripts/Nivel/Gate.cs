using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{

    private bool gateActivada = false;

    void Awake()
    {
        gateActivada = false;
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver) return;
    }

    private void OnTriggerEnter2D(Collider2D gate)
    {
        if (gate.CompareTag("Player"))
        {
            gateActivada = true;
            SceneManager.LoadScene("Level2");
        }
    }
}
