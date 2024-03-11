using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static MadamBoss;

public class CasinoMan : EntityEnemys, INavMeshAgent, IDamagable
{
    //TP2 Marques Polich
    public Transform puntoA;
    public Transform puntoB;
    public Transform destinoActual;
    private NavMeshAgent navMeshAgent;
    public float distanciaUmbral = 1f;  // Distancia umbral para cambiar de destino
    public float velocidadAgente = 10f; 
    private Animator animator;
    public GameObject instan;
    public float maxLife = 100;
    public GameObject soundDie;

    delegate void myDelegate();
    myDelegate callDelegate;

    public GameObject bullet;
    public LayerMask layerM;
    public Transform positionSp;

    public float shootDelay;
    float lastShootTime;

    Renderer renderObj;
    Color defaultColor;
    public Color newColor = Color.white;

    public Transform target;
    float dist;
    public float minDist;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = velocidadAgente;
        destinoActual = puntoA;
        Mover(destinoActual.position);
      renderObj= GetComponentInChildren<Renderer>();
        defaultColor = renderObj.material.color;
        _life = maxLife;
    }
    private void Update()
    {
        CambiarDestino();
       
        dist= Vector3.Distance(target.position, transform.position);
        
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);

      
    }
    public void Mover(Vector3 destino)
    {
       
        navMeshAgent.SetDestination(destino);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == destinoActual)
        {
            CambiarDestino();
        }
    }

    void CambiarDestino()
    {
        if (dist < minDist)
        {
            Atack();
            navMeshAgent.isStopped = true;

        }
        else
        {
            navMeshAgent.isStopped = false;
            if (Vector3.Distance(transform.position, destinoActual.position) < distanciaUmbral)
            {
                destinoActual = (destinoActual == puntoA) ? puntoB : puntoA;
                Mover(destinoActual.position);
            }
        }
       
    }

    public override void TakeDmg(float dmg)
    {
        base.TakeDmg(dmg);
        StartCoroutine(cambioColor());
        StopCoroutine(cambioColor());
    }


    IEnumerator cambioColor()
    {
        renderObj.material.color = newColor;
        yield return new WaitForSeconds(0.05f);
        renderObj.material.color = defaultColor;
        yield return null;
    }
    protected override void Muerte() 
    {
        Instantiate(soundDie);
    Destroy(gameObject);
    }
    protected override void Atack()
    {
        transform.LookAt(target); 
        if (Time.time - lastShootTime >= shootDelay)
        {
        StartCoroutine(SecAtck());
        lastShootTime = Time.time;                          
        }
        
    }

    private IEnumerator SecAtck()
    {
        shootDelay = 0.4f;
        instantiateBullet();
        yield return null;

    }

    void instantiateBullet()
    {
        Instantiate(bullet, positionSp.position, positionSp.rotation);
        bullet.GetComponent<EnemyBullet>().Initialize(layerM);
        _bulletCount--;
    }

    protected override void AudioEnemy()
    {
        
    }
}
