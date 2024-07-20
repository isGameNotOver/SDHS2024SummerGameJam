using UnityEngine;

public class TreeEnemy : Enemy
{
    private RaycastHit2D rayhit;
    private bool isAttackAnimStart;

    private void Update()
    {
        if (!isAttack && !isAttackAnimStart)
        {
            Movement();
        }
        if (!isAttack && !isAttackAnimStart)
        {
            PlayerTracking(playerCheckRange);
        }
        Attack();
    }
    protected override void PlayerTracking(float range)
    {
        base.PlayerTracking(range);
    }

    private void Attack()
    {
        Debug.DrawRay(transform.position, Vector3.right * (transform.eulerAngles.y == 0 ? -1f : 1f) * 1.3f, new Color(0, 1, 0));
        rayhit = Physics2D.Raycast(transform.position, Vector3.right * (transform.eulerAngles.y == 0 ? -1f : 1f), 1.3f, LayerMask.GetMask("Player"));

        if (rayhit.collider != null)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            isAttack = true;
            if (!isAttackAnimStart)
            {
                animator.SetTrigger("isAttack");
                isAttackAnimStart = true;
            }
        }
        else
        {
            isAttack = false;
        }
    }

    public void OnAttackEndEvent()
    {
        isAttackAnimStart = false;
    }
}
