using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float enemyHp;


    public void Damaged(float damage)
    {
        enemyHp -= damage;

        if (enemyHp <= 0)
        {
            enemyHp = 0;
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
