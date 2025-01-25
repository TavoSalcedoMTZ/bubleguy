using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int Vida=10;
    void Start()
    {
        
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
        Vida=Vida-1;
    }
}
