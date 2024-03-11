using System.Collections;
using UnityEngine;

public abstract class GunsAbs : MonoBehaviour
{
 
    //TP2 Polich
    
    [SerializeField]
    protected int _bulletCount;
    [SerializeField]
    protected int _maxBullets;
    
    protected int _bulletCharge;
    
    protected int _mediumBullets;
    [SerializeField]
    public int charge;
    [SerializeField]
    protected int _maxCharge;

    [SerializeField]
    protected float gunDmg;

    public LayerMask maskAtack;

    public GameObject entity;

    public GameObject bullet;

    [SerializeField]
    protected float _shootD = 0.2f;
    [SerializeField]
    protected float _lastBullet;

    public bool shooting;

    private AudioSource _audioSource;



    public enum typeAtacks
    {
        first,
        second
        
    }
    public typeAtacks actualType = typeAtacks.first;


    protected virtual void Charge()
    {
        if (Input.GetKeyDown(KeyCode.R) && charge >= 1)
        {

            charge--;

            _mediumBullets = _maxBullets - _bulletCount;

            _bulletCount += _mediumBullets;
        }

    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    protected virtual void Update()
    {
        if (charge >= _maxCharge)
        {
            charge = _maxCharge;
        }

        Shoot();
        Charge();
    }




    protected virtual void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _bulletCount >= 1)
        {
            shooting = true;
            _audioSource.Play();
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0) || _bulletCount <= 0)
        {
            shooting = false;
        }
        if (shooting != true)
        {
            return;
        }
        if (Time.time - _lastBullet > _shootD)
        {
            switch (actualType)
            {
                case typeAtacks.first:
                    StartCoroutine(ShootingAuto());
        _lastBullet = Time.time;
                    return;
                case typeAtacks.second:
                    StartCoroutine(ShootingBurst());
        _lastBullet = Time.time;
                    return;
            }
        }
    }

    protected abstract IEnumerator ShootingAuto();    
    protected abstract IEnumerator ShootingBurst();    
}
