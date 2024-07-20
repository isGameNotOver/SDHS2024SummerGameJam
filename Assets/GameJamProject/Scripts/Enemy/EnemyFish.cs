using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyFish : Enemy
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    private RaycastHit2D rayhit;


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
        Detect(playerCheckAttack);
    }

    protected override void PlayerTracking(float range)
    {
        base.PlayerTracking(range);
    }

    private void Detect(float range)
    {
        Debug.DrawRay(transform.position, Vector3.right * (transform.eulerAngles.y == 0 ? -1f : 1f) * 4f, new Color(0, 1, 0));
        rayhit = Physics2D.Raycast(transform.position, Vector3.right * (transform.eulerAngles.y == 0 ? -1f : 1f), 4f, LayerMask.GetMask("Player"));

        if (rayhit.collider != null)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            isAttack = true;
            animator.SetBool("isAttack", true);

        }
        else
        {
            isAttack = false;
            animator.SetBool("isAttack", false);
        }
    }
    public void Attack()
    {
        if (rayhit.collider == null)
        {
            return;
        }

        if (transform.eulerAngles.y == 0)
        {
            var go = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            go.GetComponent<BulletMovement>().SetDirection(Vector2.left);
        }
        else
        {
            var go = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            go.GetComponent<BulletMovement>().SetDirection(Vector2.right);
        }

        Debug.Log("damage");
    }
}
