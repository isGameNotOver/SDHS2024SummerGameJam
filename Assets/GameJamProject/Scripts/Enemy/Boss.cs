using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private void Update()
    {
        PlayerTracking(playerCheckRange);
    }
}
