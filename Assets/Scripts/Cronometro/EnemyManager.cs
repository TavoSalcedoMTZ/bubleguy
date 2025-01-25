using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int totalEnemiesAlive = 0; // N�mero de enemigos que est�n vivos en la escena

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
        // Retorna verdadero si a�n quedan enemigos vivos
        return totalEnemiesAlive > 0;
    }
}
