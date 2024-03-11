using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreLife : MonoBehaviour, ICollectible
{

    //TP2 Vintar
    public GameObject sound;
    public LifeManager life;
    public float moreLife;
    public float rotationVelocity = 100f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationVelocity * Time.deltaTime);
    }
    public void Plus()
    {

        Instantiate(sound);

        for (int i = 0; i < 1; i++)
        {
            life.MoreLife(moreLife);
            Destroy(gameObject);
        }
    }
}
