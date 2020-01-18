using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    // private Movement movement;

    // Movement
    private KeyCode[] keys;
        
    // Animation
    private Animator anim;

    // Grounding
    [SerializeField] private Transform groundCollider;
    [SerializeField] private LayerMask ground;
    private bool isGrounded;

    private Rigidbody2D rb;

    public float jumpForce = 5f;
    public float ExtraJumpGravity;
    public float ExtraFallGravity;
    public float ExtraLowJumpGravity;


    private bool isJumping;
    private bool stopJumping;

    void Awake() {
        keys = new KeyCode[4];
        keys[0] = KeyCode.W;
		keys[1] = KeyCode.A;
		keys[2] = KeyCode.S;
		keys[3] = KeyCode.D;

        isGrounded = false;
        isJumping = false;
    }

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        // movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCollider.transform.position, 0.2f, ground);
    }

    // Update is called once per frame
    void Update() {
        if (!Input.GetKey(keys[1]) && !Input.GetKey(keys[3])){
            // movement.setWalkingLeft(false);
            // movement.setWalkingRight(false);
        }
        if(Input.GetKeyDown(keys[0]) && isGrounded && !isJumping) {
            rb.velocity += Vector2.up*jumpForce;  
            isJumping = true;
        }if(Input.GetKeyUp(keys[0])) {
            isJumping = false;
        }
        if(rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (ExtraFallGravity) * Time.deltaTime;
        } else if(rb.velocity.y > 0 && !isJumping){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (ExtraLowJumpGravity) * Time.deltaTime;
        } else if(rb.velocity.y > 0 && isJumping){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (ExtraJumpGravity) * Time.deltaTime;
        }



        if (Input.GetKey(keys[1]) && !Input.GetKey(keys[3])) {
            // Left
            // movement.setWalkingLeft(true);
            // movement.setWalkingRight(false);
        }
        if (Input.GetKey(keys[2])) {
            // Down

        }
        if (Input.GetKey(keys[3]) && !Input.GetKey(keys[1])) {
            // Right
            // movement.setWalkingLeft(false);
            // movement.setWalkingRight(true);
        }
        
        // anim.SetBool("walkingLeft", movement.isWalkingLeft());
        // anim.SetBool("walkingRight", movement.isWalkingRight());
    }
}
