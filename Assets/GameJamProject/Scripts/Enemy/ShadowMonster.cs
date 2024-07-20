using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMonster : Enemy
{
    private void Update()
    {
        Movement();
        PlayerTracking(playerCheckRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StatManager.instance.PlayerCurHp -= 5;
        }
    }
}
