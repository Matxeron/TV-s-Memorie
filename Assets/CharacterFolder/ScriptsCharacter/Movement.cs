using UnityEngine;

public class Movement 
{

    //TP2 Marques
    Camera _cam;
    Rigidbody _rb;
    public float speed = 4;
    Transform transform;
    float rotateSpeed = 1;

    public Movement (Rigidbody rb, float _speed, Camera cam, Transform _transform)
    {
        _rb = rb;
        speed = _speed;
        _cam = cam;
        transform = _transform; 
    }

    public void move(float h, float v)
    {
        var dir = _cam.transform.forward * v + _cam.transform.right * h;
       
        dir.y = 0;
        

        _rb.velocity = dir.normalized * speed;

        Vector3 _newRotate = Vector3.Lerp(transform.forward, dir, rotateSpeed * Time.fixedDeltaTime);

        transform.forward = _newRotate;
       
    }

    public void stop() 
    {
        
            _rb.velocity = Vector3.zero;
    }
}
