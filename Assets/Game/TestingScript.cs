using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour {


    [SerializeField] private GameObject player;

    void Start(){}

    void Update(){
        if(Input.GetButtonDown("TestingButton")){
            player.GetComponent<HealthStat>().TakeDamage(1f);
        }
        
    }
}
