using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    private float DEFAULT_CAMERA_SPEED;

    [SerializeField]
    private GameObject player;
    private Vector3 playerOffset;
    [SerializeField]
    private float cameraSpeed;

    // Start is called before the first frame update
    void Start() {
        playerOffset = player.transform.position - transform.position;
        DEFAULT_CAMERA_SPEED = cameraSpeed;
    }

    void FixedUpdate() {
        panTo(player.transform.position - playerOffset);
    }

    void panTo(Vector3 v){
        transform.position = Vector3.Lerp(transform.position, v, cameraSpeed * Time.deltaTime);
    }
}
