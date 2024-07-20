using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFish : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Quaternion quaternion;

    private void Start()
    {
        StartCoroutine(Attack());
    }
    private void Update()
    {
        if (!isPlayerCheck && !isAttack)
        {
            Movement();
        }
        if (!isAttack)
        {
            PlayerTracking(playerCheckRange);
        }
    }

    protected override void PlayerTracking(float range)
    {
        isPlayerCheck = Physics2D.OverlapCircle(transform.position, range, chaseTarget);

        if (isPlayerCheck)
        {
            if (transform.position.x < playerTransform.position.x)
            {
                rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (transform.position.x > playerTransform.position.x)
            {
                rigid.velocity = new Vector2(-moveSpeed, rigid.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            if (isPlayerCheck)
            {
                if ((Mathf.Abs(transform.position.y - playerTransform.position.y) < 2f) && (Mathf.Abs(transform.position.x - playerTransform.position.x) < 2f))
                {
                    isAttack = true;
                    Vector3 euler = transform.rotation.eulerAngles;

                    quaternion = bullet.transform.rotation;
                    quaternion = Quaternion.Euler(quaternion.eulerAngles.x, quaternion.eulerAngles.y, euler.y);
                    yield return new WaitForSeconds(1f);
                    Instantiate(bullet, firePoint.position, quaternion);
                    isAttack = false;
                }
            }

            yield return null;
        }
    }
}
