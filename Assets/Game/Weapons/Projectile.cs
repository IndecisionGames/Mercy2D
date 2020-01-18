using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public int damage;

    private Vector2 shootDirection;

    public void FireProjectile(Ray2D shootRay){
        shootDirection = shootRay.direction.normalized;
        this.transform.position = shootRay.origin;
        this.GetComponent<Rigidbody2D>().AddForce(shootDirection*speed*100);
        this.GetComponent<Rigidbody2D>().AddTorque(-4);
    }

}
