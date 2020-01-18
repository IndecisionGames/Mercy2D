using UnityEngine;

public class ParallaxLayer : MonoBehaviour{

    public Vector3 movementScale = Vector3.one;

    private Vector3 origin;
    private Vector3 camera_origin;

    Transform _camera;

    void Awake(){
        _camera = Camera.main.transform;
        origin = transform.position;
        camera_origin = _camera.position;
    }

    void LateUpdate(){
        transform.position = origin + Vector3.Scale(_camera.position - camera_origin, movementScale);
    }

}
