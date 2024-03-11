using UnityEngine;

public class WallBlock : MonoBehaviour
{
    //TP2 Polich
    public float damageFromWall = 1f;
    public float rotationSpeed = 250.0f;
    public float maxHeight = 5.0f;
    public float oscilationVelocity = 10.0f;

    private void Update()
    {
        float newHeight = Mathf.PingPong(Time.time * oscilationVelocity, maxHeight);
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        LifeManager x = otherRigidbody.GetComponent<LifeManager>();

        if (otherRigidbody != null)
        {
            x.TakeDmg(damageFromWall);
        }
    }
}
