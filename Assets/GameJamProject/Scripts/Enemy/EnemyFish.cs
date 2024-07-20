using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFish : Enemy
{
    private bool isAttack = false;

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
        if(!isAttack)
        PlayerTracking(playerCheckRange);
        Attack(attackRange);
    }

    private void Attack(float range)
    {
        isAttack = Physics2D.OverlapCircle(transform.position, range, chaseTarget);
        if(isAttack)
        {
            if (Mathf.Abs(transform.position.y - playerTransform.position.y) < 0.1f)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
                Debug.Log("АјАн!!!!!!");
            }
        }
    }
}
