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
}
