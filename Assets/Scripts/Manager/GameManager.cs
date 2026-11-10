using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public bool isGameOver; // Para saber si la partida ha terminado
    
    private static GameManager instance;
    public static GameManager Instance {get {return instance;}}

    // Sistema de coins acumulados entre niveles
    public static int coinsTotalesAcumulados = 0; 
    public int coinsPartidaActual = 0;

    private int score = 0;
    public TMP_Text scoreText; // Arrastrar texto de la UI

    public GameObject panelEND;
    public TMP_Text textoPuntuacion;

    void Awake() // Se ejecuta automaticamente cuando se carga un GameObject,
                 // antes de que empiece el juego o antes de que se ejecute Start()
    {
        // Comprueba si ya existe un GameManager
        if (instance == null) // Si no existe, guarda el objeto como instancia
        {
            instance = this;
        }
        else // Si existe
        {
            Destroy(gameObject); // Destruye el duplicado
            return;
        }

        // Si estamos empezando desde el Nivel 1, borramos la memoria de los coins anteriores
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            PlayerPrefs.SetInt("CoinsAcumulados", 0);
            PlayerPrefs.Save();
        }

        // Cargamos los coins acumulados que llevamos hasta ahora
        coinsTotalesAcumulados = PlayerPrefs.GetInt("CoinsAcumulados", 0);
    }


    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isGameOver) // Si se pulsa clic derecho o espacio y es game over
        {
            RestartGame(); // Reempezamos juego
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        if (gameOverText != null) // Comprobamos que exista escena
        {
            gameOverText.SetActive(true);
        }

        Debug.Log("¡OH NO! Has tocado un obstaculo");
    }

    private void  RestartGame()
    {
        Time.timeScale = 1f; 

        // CUENTA DE COINS
        // Al morir y reiniciar, restamos lo que cogimos en este intento fallido para no inflar la cuenta
        int coinsPrevios = coinsTotalesAcumulados - coinsPartidaActual;
        PlayerPrefs.SetInt("CoinsAcumulados", coinsPrevios); 
        PlayerPrefs.Save();

        score = 0; // Reinicia la puntuación si el jugador muere
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarga la escena actual
    }

    public void SumarPuntos(int puntos)
    {
        if (isGameOver) return; // Si morimos no sumamos puntos

        score += puntos;

        // Incrementamos los contadores de coins
        coinsPartidaActual++;
        coinsTotalesAcumulados++;

        // Guardamos en tiempo real en la memoria del juego
        PlayerPrefs.SetInt("CoinsAcumulados", coinsTotalesAcumulados); //
        PlayerPrefs.Save();

        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // ToString --> Convierte num entero a una cadena
        }

        Debug.Log("Puntuacion actual: " + score);
    }

    public void MostrarEND()
    {
        // Pausamos el juego
        Time.timeScale = 0f;

        // Activamos el panel END si está asignado
        if (panelEND != null)
        {
            panelEND.SetActive(true);
        }

        // Mostramos la puntuación total acumulada
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = coinsTotalesAcumulados.ToString();
        }

        Debug.Log("¡Juego completado! Mostrando en pantalla End con total de coins: " + coinsTotalesAcumulados);
    }
}
