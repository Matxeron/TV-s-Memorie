using System.Collections;
using UnityEngine;

public class MadamBoss : EntityEnemys, IDamagable
{
    //TP2 Vintar
    [SerializeField]
    float lastShootTime;
    public float shootDelay = 0.8f;
    public GameObject bullet;
    public LayerMask layerM;
    public GameObject positionSp;
    public Transform player;
    public float minDist;
    public float dist;
    [SerializeField]
    int maxBullets;
    public float chargeDelay = 2;
    float lastRecharge;

    Rigidbody rb;
    delegate void myDelegate();
    myDelegate myCallback;

    //Movimiento por waypoints
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float velocidadMovimiento = 10;
    public float distanciaUmbral;
    public float suavidadRotacion = 5f;

    public bool evento = false;

    public enum typeAtacks
    {
        first,
        angry,
        lowlife
    }
    public typeAtacks actualType = typeAtacks.first;

    private void Start()
    {
        myCallback = Atack;
        rb = GetComponent<Rigidbody>();
        MoverHaciaWaypoint();
        
    }

    void Update()
    {
        if (evento)
        {
            return;
        }
        minDist = Vector3.Distance(player.position, transform.position);
        LifeManagement();
        if (minDist < dist)
        {
            velocidadMovimiento = 3f;
            myCallback();
        }
        else { velocidadMovimiento = 10f; }

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < distanciaUmbral)
        {
            CambiarWaypoint();
        }
        MoverHaciaWaypoint();
    }

    void MoverHaciaWaypoint()
    {
        Vector3 direccion = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        transform.Translate(direccion * velocidadMovimiento * Time.deltaTime, Space.World);
        if (minDist > dist)
        {
            Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, suavidadRotacion * Time.deltaTime);
        }
    }

    void CambiarWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        if (currentWaypointIndex == 0)
        {
            System.Array.Reverse(waypoints);
        }
        MoverHaciaWaypoint();
    } 
    void RechargeMoment()
    {
        float rechargeDelay = 0.3f;
        if (Time.time - lastRecharge >= rechargeDelay)
        {
            if (_bulletCount <= maxBullets)
            {
                _bulletCount++;
            }
            else
            {
                myCallback = Atack;
            }
            lastRecharge = Time.time;
        }
    }

    protected override void Atack()
    {
        
        transform.LookAt(player);

        if (Time.time - lastShootTime >= shootDelay)
        {
            switch (actualType)
            {
                case typeAtacks.first:
                    StartCoroutine(SecAtck());
                    lastShootTime = Time.time;
                    return;
                case typeAtacks.angry:
                    StartCoroutine(shootBurst());
                    lastShootTime = Time.time;
                    return; 
                case typeAtacks.lowlife:
                    StartCoroutine(OnlyRatatata());
                    lastShootTime = Time.time;
                    return;
            }
        }
        if (_bulletCount <= 1)
        {
            myCallback = RechargeMoment;
        }

    }

    void instantiateBullet()
    {
        Instantiate(bullet, positionSp.transform.position, positionSp.transform.rotation);
        bullet.GetComponent<EnemyBullet>().Initialize(layerM);
        _bulletCount--;
    }
    private IEnumerator SecAtck() 
    {
        shootDelay = 0.4f;
            instantiateBullet();
            yield return null;
        
    }
    private IEnumerator shootBurst()
    {
        int bulletCount = 3;
        float burstDelay = 0.1f;
        
        for (int i = 0; i < bulletCount; i++)
        {
            instantiateBullet();
            yield return new WaitForSeconds(burstDelay);
        }
    }

    private IEnumerator OnlyRatatata()
    {
        shootDelay = 0.2f;
        instantiateBullet();
        yield return null;
    }

    protected override void AudioEnemy()
    {
    }

   public void LifeManagement()
    {
        if (_life <= _life/2)
        {
            actualType = typeAtacks.first;
        }
        else if (_life <= _life/4)
        {
            actualType = typeAtacks.lowlife;
        }      
    }

    protected override void Muerte()
    {
        Destroy(gameObject);
    }

    public GameObject win;

    private void OnDestroy()
    {
        if (win != null)
        {
            win.SetActive(true);
        }
    }
}
