using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = default;
    [SerializeField] protected float playerCheckRange = default;
    [SerializeField] protected float playerCheckAttack = default;
    [SerializeField] protected bool isPlayerCheck;
    [SerializeField] protected bool isAttack = false;
    [SerializeField] protected LayerMask chaseTarget = default;
    [SerializeField] protected Transform playerTransform;
    [SerializeField] protected Transform gizmoAttack;
    [SerializeField] protected Animator animator;


    protected Vector3 moveVelocity;
    protected Rigidbody2D rigid;
    protected bool isLeft = true;

    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
    }

    protected virtual void Movement()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    protected virtual void PlayerTracking(float range)
    {
        isPlayerCheck = Physics2D.OverlapCircle(transform.position, range, chaseTarget);

        if (isPlayerCheck)
        {
            if (transform.position.x < playerTransform.position.x)
            {
                rigid.velocity = new Vector2(moveSpeed * Time.deltaTime, rigid.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (transform.position.x > playerTransform.position.x)
            {
                rigid.velocity = new Vector2(-moveSpeed * Time.deltaTime, rigid.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPoint"))
        {
            if (isLeft)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isLeft = true;
            }
        }
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerCheckRange);
    }
}
