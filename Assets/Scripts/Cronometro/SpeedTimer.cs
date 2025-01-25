using UnityEngine;
using TMPro; // Para usar TextMeshPro

public class SpeedTimer : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public Transform[] spawnPoints; // Puntos de spawn para los enemigos
    public int maxEnemies = 5; // Número máximo de enemigos que pueden aparecer
    public TextMeshProUGUI timerText; // Referencia al texto del cronómetro
    public TextMeshProUGUI speedText; // Referencia al texto de la velocidad

    private int totalEnemies = 0; // Número total de enemigos generados
    private int defeatedEnemies = 0; // Número de enemigos derrotados

    public float timerDuration = 10f; // Duración del cronómetro
    private float currentTime;
    private bool timerRunning = false;

    private PlayerMovement originalScript; // Referencia al script original
    private EnemyManager enemyManager; // Referencia al script EnemyManager

    void Start()
    {
        currentTime = timerDuration;
        originalScript = FindObjectOfType<PlayerMovement>();
        enemyManager = FindObjectOfType<EnemyManager>();

        timerRunning = true;

        // Generar enemigos aleatoriamente
        SpawnEnemies();
        UpdateUI();
    }

    void Update()
    {
        if (timerRunning)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateUI();
            }
            else
            {
                currentTime = 0;
                TimerEnd();
            }

            // Verificar si quedan enemigos
            if (!enemyManager.AreEnemiesPresent() && defeatedEnemies == totalEnemies)
            {
                StopTimerEarly();
            }
        }
    }

    void SpawnEnemies()
    {
        // Genera enemigos de forma aleatoria en los puntos de spawn
        totalEnemies = Random.Range(3, maxEnemies + 1); // Genera entre 3 y maxEnemies enemigos
        for (int i = 0; i < totalEnemies; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length); // Escoge un punto de spawn aleatorio
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }

    public void EnemyDefeated()
    {
        // Aumentar el contador de enemigos derrotados
        defeatedEnemies++;

        // Verificar si todos los enemigos han sido derrotados
        if (defeatedEnemies == totalEnemies)
        {
            StopTimerEarly();
        }
    }

    void TimerEnd()
    {
        timerRunning = false;

        // Disminuir la velocidad si el tiempo termina
        if (originalScript != null)
        {
            originalScript.moveSpeed -= 1f;
        }

        UpdateUI();
        Debug.Log("Tiempo terminado. Nueva velocidad: " + originalScript.moveSpeed);
    }

    public void StopTimerEarly()
    {
        if (timerRunning)
        {
            timerRunning = false;

            // Aumentar la velocidad si todos los enemigos son derrotados
            if (originalScript != null)
            {
                originalScript.moveSpeed += 2f;
            }

            UpdateUI();
            Debug.Log("Todos los enemigos derrotados. Nueva velocidad: " + originalScript.moveSpeed);
        }
    }

    void UpdateUI()
    {
        // Actualizar el texto del cronómetro
        timerText.text = "Tiempo: " + currentTime.ToString("F2");

        // Actualizar el texto de la velocidad
        if (originalScript != null)
        {
            speedText.text = "Velocidad: " + originalScript.moveSpeed;
        }
    }
}
