using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int Vida = 10;
    private EnemyManager enemyManager;
    void Start()
    {
        // Obtener el EnemyManager desde la escena
        enemyManager = FindObjectOfType<EnemyManager>();

        if (enemyManager != null)
        {
            // Registrar el enemigo en el EnemyManager
            enemyManager.RegisterEnemy(this);
        }
    }

    public void Defeat()
    {
        // Notificar al EnemyManager que este enemigo ha sido derrotado
        if (enemyManager != null)
        {
            enemyManager.EnemyDefeated();
        }

        // Aquí puedes poner cualquier lógica para destruir el enemigo
        Destroy(gameObject);
    }

    void Update()
    {
        if (Vida <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void DicreseVida()
    {
        Vida = Vida - 1;
    }

}