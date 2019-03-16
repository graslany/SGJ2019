using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float maxSpeed = 5f;
    public float jumpForce = 8;
    public Transform groundCheck;


    private bool grounded = false;
    // private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake () 
    {
        // anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () 
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Submit") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        // anim.SetFloat("Speed", Mathf.Abs(h));

		float targetSpeed = h * maxSpeed;
		float speedDelta = targetSpeed - rb2d.velocity.x;
        rb2d.AddForce(Vector2.right * speedDelta * rb2d.mass, ForceMode2D.Impulse);

        if (h > 0 && !facingRight)
            Flip ();
        else if (h < 0 && facingRight)
            Flip ();

        if (jump)
        {
            // anim.SetTrigger("Submit");
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}