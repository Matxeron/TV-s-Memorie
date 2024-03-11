
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //TP2 Polich
    public LayerMask layerMask;
    public float myDmg = 5;

    [SerializeField]
    int _speed;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

            _rb.velocity = transform.forward* _speed;
    }
    public void Initialize(LayerMask mask)
    {
        layerMask = mask;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (layerMask == (layerMask | (1 << other.gameObject.layer)))
        {
            IDamagable x = other.GetComponent<IDamagable>();
           
            if (x != null)
                x.TakeDmg(myDmg);

        }

        Destroy(gameObject);


    }
}

