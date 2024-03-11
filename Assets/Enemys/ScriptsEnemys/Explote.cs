
using UnityEngine;

public class Explote : MonoBehaviour
{
    //TP2 Polich
    public float dmg;
    private void OnTriggerEnter(Collider other)
    {
        IDamagable x = other.GetComponent<IDamagable>();
        if (x!=null)
        {
            other.GetComponent<IDamagable>().TakeDmg(dmg);
        }
        Destroy(gameObject);

    }
}
