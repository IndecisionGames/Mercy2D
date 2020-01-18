using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Movement movement;

    // Movement
    private KeyCode[] keys;
        
    // Animation
    private Animator anim;

    // Grounding
    [SerializeField]
    private Transform groundCollider;
    [SerializeField]
    private LayerMask ground;
    private bool isGrounded;
    private float jumpCooldown = 0.1f;
    private float jumpTimer;
    private bool jumpAllowed;

    void Awake() {
        keys = new KeyCode[4];
        keys[0] = KeyCode.W;
		keys[1] = KeyCode.A;
		keys[2] = KeyCode.S;
		keys[3] = KeyCode.D;

        isGrounded = false;
        jumpTimer = Time.time;
        jumpAllowed = true;
    }

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCollider.transform.position, 0.2f, ground);
    }

    // Update is called once per frame
    void Update() {
        if (!Input.GetKey(keys[1]) && !Input.GetKey(keys[3])){
            movement.setWalkingLeft(false);
            movement.setWalkingRight(false);
        }
        if(!Input.GetKey(keys[0])) jumpAllowed = true;
        if(Input.GetKey(keys[0]) && isGrounded && Time.time > jumpTimer + jumpCooldown && jumpAllowed) {
            // Up
            movement.jump();
            isGrounded = false;
            jumpTimer = Time.time;
            jumpAllowed = false;
        }
        if (Input.GetKey(keys[1]) && !Input.GetKey(keys[3])) {
            // Left
            movement.setWalkingLeft(true);
            movement.setWalkingRight(false);
        }
        if (Input.GetKey(keys[2])) {
            // Down

        }
        if (Input.GetKey(keys[3]) && !Input.GetKey(keys[1])) {
            // Right
            movement.setWalkingLeft(false);
            movement.setWalkingRight(true);
        }
        
        anim.SetBool("walkingLeft", movement.isWalkingLeft());
        anim.SetBool("walkingRight", movement.isWalkingRight());
    }
}
