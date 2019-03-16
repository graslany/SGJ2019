using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {

    public float maxSpeed = 5f;
    public float jumpForce = 8;
    public ProximityChecker groundCheck;

    private bool willJump = false;
    private bool isGrounded = true;

    private SpriteRenderer bobRenderer;
    private Animator bobAnimator;
    private Rigidbody2D bobPhysics;


    // Use this for initialization
    void Awake () 
    {
        bobRenderer = GetComponentInChildren<SpriteRenderer>();
        bobAnimator = GetComponentInChildren<Animator>();
        bobPhysics = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () 
    {
        isGrounded = groundCheck.HasAnyCloseObject();
        willJump = (
            Input.GetButtonDown("Jump") &&
            isGrounded && // No double jump in this game for now
            bobPhysics.velocity.y <= 0); // Same reason: tapping jump twice when very close to the ground may result in double jump.
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the character
		float targetSpeed = horizontalInput * maxSpeed;
		float speedDelta = targetSpeed - bobPhysics.velocity.x;
        bobPhysics.AddForce(Vector2.right * speedDelta * bobPhysics.mass, ForceMode2D.Impulse);
        if (willJump)
        {
            bobPhysics.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            willJump = false;
        }

        // Flip the sprit if relevant
        if (targetSpeed != 0) {
            bobRenderer.flipX = (targetSpeed < 0);
        }

        // Play the proper animation
        bobAnimator.SetBool("isGrounded", isGrounded);
        bool isMovingSideways = (bobPhysics.velocity.x != 0);
        bobAnimator.SetBool("isMovingSideways", isMovingSideways);
    }
}