using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilityStat : MonoBehaviour
{

    public StatHolder MaxSpeed;
    public StatHolder Acceleration;

    void Start(){
        MaxSpeed.Initialize();
        Acceleration.Initialize();
    }

}
