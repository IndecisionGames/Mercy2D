using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public Projectile projectilePrefab;
    public LayerMask mask;

    void shoot(Ray2D shootRay){

        var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();

        Debug.DrawRay(shootRay.origin, shootRay.direction*2, Color.green, 2, false);

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), projectile.GetComponent<Collider2D>());

        projectile.FireProjectile(shootRay);
    }

    void raycastOnMouseClick() {
        var mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos - transform.position, Mathf.Infinity, mask);
        var direction = mousePos - transform.position;
        var shootRay = new Ray2D(transform.position, direction);
        shoot(shootRay);
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            raycastOnMouseClick();  
        }
    }

}
