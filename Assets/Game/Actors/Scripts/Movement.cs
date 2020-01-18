using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    public static float DEFAULT_MAX_VELOCITY = 4.0f;
    [HideInInspector]
    public static float DEFAULT_JUMP_FORCE = 6.2f;
    [HideInInspector]
    public static float DEFAULT_ACCELERATION = 7.5f;
    [HideInInspector]
    public static float DEFAULT_DECELERATION = 8.0f;

    // Movement
    private bool walkingLeft, walkingRight;
    [HideInInspector]
    public float maxVelocity, jumpForce, acceleration, deceleration;
    [HideInInspector]
    public Vector2 currentVelocity;

     private PlayerMovementStat movementStat;
  
    // Physics
    private Rigidbody2D rb;

    public bool isWalkingLeft() {return walkingLeft;}
    public bool isWalkingRight() {return walkingRight;}
    public void setWalkingLeft(bool b) {walkingLeft = b;}
    public void setWalkingRight(bool b) {walkingRight = b;}

    public void jump() {
        jumpForce = movementStat.Jump.GetValue();
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void Awake() {
        walkingLeft = false;
        walkingRight = false;

        maxVelocity = DEFAULT_MAX_VELOCITY;
        jumpForce = DEFAULT_JUMP_FORCE;
        acceleration = DEFAULT_ACCELERATION;
        deceleration = DEFAULT_DECELERATION;
    }

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        movementStat = GetComponent<PlayerMovementStat>();
    }


    //TODO:
    // "Coyote time" - being able to jump while off platform
    // Fix player collider to prevent floating

    void FixedUpdate() {
        maxVelocity = movementStat.MaxSpeed.GetValue();
        acceleration = movementStat.Acceleration.GetValue();
        deceleration = movementStat.Deceleration.GetValue();
        currentVelocity = rb.velocity;
        if(walkingLeft) {
            if(currentVelocity[0] < -maxVelocity) {
                rb.AddForce(new Vector2((Mathf.Abs(currentVelocity[0]) - maxVelocity) / deceleration, 0));
            } else if (currentVelocity[0] > 0) {
                rb.AddForce(new Vector2(-(acceleration + deceleration), 0));
            } else {
                rb.AddForce(new Vector2(-acceleration, 0));
            }
        } else if(walkingRight) {
            if(currentVelocity[0] > maxVelocity) {
                rb.AddForce(new Vector2(-(currentVelocity[0] - maxVelocity) / deceleration, 0));
            } else if (currentVelocity[0] < 0) {
                rb.AddForce(new Vector2(acceleration + deceleration, 0));
            } else {
                rb.AddForce(new Vector2(acceleration, 0));
            }
        } else {
            //if(Mathf.Abs(currentVelocity[0]) < 0.1f){
            //    rb.velocity = new Vector2(0,0);
            //}
            if(currentVelocity[0] > 0) {
                rb.AddForce(new Vector2(-deceleration, 0));
            } else if (currentVelocity[0] < 0) {
                rb.AddForce(new Vector2(deceleration, 0));
            }
        }
        if(currentVelocity[1] > maxVelocity) {
            rb.AddForce(new Vector2(0, -deceleration));
        } else if (currentVelocity[1] < -maxVelocity) {
            rb.AddForce(new Vector2(0, deceleration));
        }
    }
}
