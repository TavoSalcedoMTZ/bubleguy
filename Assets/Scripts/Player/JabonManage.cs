using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabonManage : MonoBehaviour
{
    public int Jabon=15;
    private DisparoPlayer player;

    void Start()
    {
        player=GetComponent<DisparoPlayer>();

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
         Jabon=Jabon-_cantidadjabon;
    }

    public void JabonIncremense(int _cantidadjabon)
    {
        Jabon=Jabon+_cantidadjabon;
    }
}
