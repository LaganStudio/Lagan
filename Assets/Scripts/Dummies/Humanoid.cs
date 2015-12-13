using UnityEngine;
using System.Collections;

public class Humanoid : MonoBehaviour, IMovable
{
    public float maxSpeed = 30;
    public float jumpSpeed = 10;
    public float groundCheckerRadius = 0.2f;
    public Transform groundChecker;
    public LayerMask whatIsGround;

    protected bool isFacingRight = true;
    protected bool isGrounded = false;
    protected bool isButtonPressed = false;

    protected Rigidbody2D rb2D;
    protected Collider2D c2D;
    protected Animator anim;
    protected Transform tran;

    protected void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tran = GetComponent<Transform>();
    }

    public void Move(float move)
    {
        if (Mathf.Abs (move) > 0.1f) {
            isButtonPressed = true;
        } else {
            isButtonPressed = false;
        }
        rb2D.velocity = new Vector2(move * maxSpeed, rb2D.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            isGrounded = false;
            anim.SetBool("isGrounded", isGrounded);
        }
    }

    protected void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, whatIsGround);
    }

    protected void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = tran.localScale;
        newScale.x *= -1;
        tran.localScale = newScale;
    }

    protected void SetAnimatorParameters()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool ("isButtonPressed", isButtonPressed);
        anim.SetFloat("vSpeed", rb2D.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        AnimatorStateInfo a = anim.GetCurrentAnimatorStateInfo(0);
        if (a.IsName("Run"))
        {
            anim.speed = Mathf.Abs(rb2D.velocity.x) / maxSpeed;
        }
        else
        {
            anim.speed = 1;
        }
    }

    protected void FacingHandler()
    {
        if ((rb2D.velocity.x < -0.1) && isFacingRight && isButtonPressed)
        {
            Flip();
            } else if((rb2D.velocity.x > 0.1) && !isFacingRight && isButtonPressed)
            {
                Flip();
            }
        }
    }
