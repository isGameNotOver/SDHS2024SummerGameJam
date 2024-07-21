using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMonster : Enemy
{
    protected override void Start()
    {
        enemyDamage = 5f;
        base.Start();
    }

    private void Update()
    {
        Movement();
        PlayerTracking(playerCheckRange);
    }
}
