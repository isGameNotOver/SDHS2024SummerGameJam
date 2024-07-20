using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float movePower = 1f;
    public float jumpPower = 1f;
    public int jumpCount = 1;

    public LayerMask groundMask;

    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private Vector2 groundBoxSize = new Vector2();
    private Rigidbody2D rigid;
    private Animator animator;

    [SerializeField] bool isJumping = false;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        GroundCheck();
    }


    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("isMove", true);
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
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
        if (rigid.velocity.y < 0)
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
}