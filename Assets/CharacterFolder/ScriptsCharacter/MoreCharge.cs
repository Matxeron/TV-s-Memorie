using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreCharge : MonoBehaviour, ICollectible
{
    //TP2 Vintar
    public GameObject sound;
    public NormalGun gun;
    public float rotationVelocity = 100;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationVelocity * Time.deltaTime);    
    }
    public void Plus()
    {
        Instantiate(sound);

        for (int i = 0; i < 1; i++)
        {
            gun.charge++;
            Destroy(gameObject);
        }
    }
    
}
