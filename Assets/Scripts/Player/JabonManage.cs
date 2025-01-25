using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabonManage : MonoBehaviour
{
    public int Jabon = 15;
    private DisparoPlayer player;
    public Transform playerTransf;
    private Vector3 initialScale;
    private float maxJabon = 15f;  // Valor máximo de Jabón

    void Start()
    {
        player = GetComponent<DisparoPlayer>();
        initialScale = playerTransf.localScale; // Guarda la escala inicial
    }

    void Update()
    {
        if (Jabon <= 0)
        {
            Debug.Log("Te has quedado sin Jabon");
            player.canShoot = false;
        }
    }

    public void JabonDicrese(int _cantidadjabon)
    {
        Jabon -= _cantidadjabon;

        Jabon = Mathf.Max(Jabon, 0);

 
        float scaleFactor = Mathf.InverseLerp(0, maxJabon, Jabon);

        playerTransf.localScale = Vector3.Lerp(Vector3.zero, initialScale, scaleFactor);
    }

    public void JabonIncremense(int _cantidadjabon)
    {
        Jabon += _cantidadjabon;

        Jabon = Mathf.Min(Jabon, (int)maxJabon);


        float scaleFactor = Mathf.InverseLerp(0, maxJabon, Jabon);
      
        playerTransf.localScale = Vector3.Lerp(Vector3.zero, initialScale, scaleFactor);
    }
}
