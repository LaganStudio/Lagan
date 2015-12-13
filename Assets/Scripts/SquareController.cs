using UnityEngine;

public class SquareController : MonoBehaviour {
    public float maxSpeed = 30;
    public float jumpSpeed = 10;
    public Transform groundChecker;
    public LayerMask whatIsGround;

    private bool facingRight = true;
    private bool isGrounded = false;
    //private bool isTouchingTheWall = false;

    private float currentSpeed = 0f;

    private Rigidbody2D rb2D;
    //private Collider2D c2D;
    private Animator anim;
    private Transform tran;
    

    void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
        //c2D = GetComponent<CircleCollider2D>();
        tran = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        isGrounded = false;
        facingRight = true;
        //isTouchingTheWall = false;
		TimePeriod tp = new TimePeriod();
		tp.Hours = 3;
		print (tp.Hours);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Moneta"))
        {
            other.gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Wall"))
        {
            //isTouchingTheWall = true;
        }
        /*if (coll.transform.CompareTag("Floor"))
        {
            isGrounded = true;
        }*/
    }
    /*void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Wall"))
        {
            isTouchingTheWall = true;
        }
        if (coll.transform.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }*/
    void OnCollisionExit2D(Collision2D coll)
    {
        /*if (coll.transform.CompareTag("Floor"))
        {
            isGrounded = false;
        }*/
    }
    // Update is called once per frame
    void Update () {
        //Debug.Log(Input.GetAxis("Horizontal"));
        currentSpeed = rb2D.velocity.x;
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb2D.AddForce(new Vector2(0f, jumpSpeed));
            isGrounded = !isGrounded;
            anim.SetBool("isGrounded", isGrounded);
        }
    }   

    
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundChecker.position, 0.2f, whatIsGround);

        rb2D.velocity = new Vector2(moveHorizontal * maxSpeed, rb2D.velocity.y);

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("vSpeed", rb2D.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(currentSpeed));

        AnimatorStateInfo a = anim.GetCurrentAnimatorStateInfo(0);
        if (a.IsName("Run"))
        {
            anim.speed = Mathf.Abs(rb2D.velocity.x) / maxSpeed;
            
        } else
        {
            anim.speed = 1;
        }


        if (currentSpeed > 0.1f && !facingRight)
        {
            Flip();
        }
        else if (currentSpeed < -0.1f && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = tran.localScale;
        Scale.x *= -1;
        tran.localScale = Scale;
    }

	class TimePeriod
	{
		private double seconds;
		
		public double Hours
		{
			get { return seconds / 3600; }
			set { seconds = value * 3600; }
		}
	}

}
