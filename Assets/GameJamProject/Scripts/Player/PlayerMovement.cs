using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float movePower = 1f;
    public float jumpPower = 1f;
    public int jumpCount = 1;

    public LayerMask groundMask;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashCooldown = 0.7f;

    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private Vector2 groundBoxSize = new Vector2();
    [SerializeField] bool isJumping = false;
    [SerializeField] float horizontal;

    private Rigidbody2D rigid;
    private Animator animator;
    private Ghost ghost;


    Vector3 moveVelocity;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ghost = GetComponent<Ghost>();
    }
    void Update()
    {
        Move();
        Jump();
        Dash();
        GroundCheck();
    }
    private void Move()
    {
        moveVelocity = Vector3.zero;
        horizontal = Input.GetAxisRaw("Horizontal");

        if (!isDashing)
        {
            if (horizontal < 0)
            {
                moveVelocity = Vector3.left;
                transform.eulerAngles = new Vector3(0, 0, 0);
                animator.SetBool("isMove", true);
            }

            else if (horizontal > 0)
            {
                moveVelocity = Vector3.right;
                transform.eulerAngles = new Vector3(0, 180, 0);
                animator.SetBool("isMove", true);
            }
            else
            {
                animator.SetBool("isMove", false);
            }

            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping && !isDashing)
        {
            animator.SetTrigger("isJump");
            isJumping = true;
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            jumpCount--;
        }

    }
    private void GroundCheck()
    {
        if (rigid.velocity.y <= 0 && isJumping)
        {
            bool isGrounded = Physics2D.OverlapBox(groundCheckPos.position, groundBoxSize, 0, groundMask);

            if (isGrounded)
            {
                isJumping = false;
                jumpCount = 1;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundCheckPos.position, groundBoxSize);
    }
    private void Dash()
    {
        if (horizontal != 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(Cor_Dash());
            }
        }
    }
    private IEnumerator Cor_Dash()
    {
        canDash = false;
        isDashing = true;
        ghost.makeGhost = true;

        float originalGravity = 3f;

        rigid.gravityScale = 0f;
        rigid.velocity = new Vector2(moveVelocity.x * dashingPower, rigid.velocity.y);

        yield return new WaitForSeconds(dashingTime);

        rigid.gravityScale = originalGravity;
        rigid.velocity = Vector2.zero;

        isDashing = false;
        ghost.makeGhost = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyAttackRange"))
            {
                StatManager.instance.PlayerCurHp -= 5;
            } 
    }
}