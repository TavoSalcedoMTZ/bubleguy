using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int totalEnemiesAlive = 0; // Número de enemigos que están vivos en la escena

    void Start()
    {
        // Asegurarse de que el contador de enemigos vivos se actualiza al inicio
        totalEnemiesAlive = FindObjectsOfType<Enemigo>().Length;
    }

    public void RegisterEnemy(Enemigo enemy)
    {
        // Cuando un enemigo es creado, lo registramos
        totalEnemiesAlive++;
    }

    public void EnemyDefeated()
    {
        // Llamado cuando un enemigo es derrotado
        totalEnemiesAlive--;
    }

    public bool AreEnemiesPresent()
    {
        // Retorna verdadero si aún quedan enemigos vivos
        return totalEnemiesAlive > 0;
    }
}
