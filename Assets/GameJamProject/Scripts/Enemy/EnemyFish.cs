using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFish : Enemy
{

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isPlayerCheck)
        {
            Movement();
        }
        PlayerTracking(chaseRange);
    }
}
