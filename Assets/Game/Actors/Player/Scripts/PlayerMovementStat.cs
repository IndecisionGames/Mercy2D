using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStat : MonoBehaviour
{

    public StatHolder MaxSpeed;
    public StatHolder Acceleration;
    public StatHolder Jump;
    public StatHolder Deceleration;

    void Start(){
        MaxSpeed.Initialize();
        Acceleration.Initialize();
        Jump.Initialize();
        Deceleration.Initialize();
    }

}
