using System;
using UnityEngine;

public class LifeManager : MonoBehaviour, IDamagable, IParticles
{
    //TP2 Marques
    [SerializeField, Range(0, 100)]
    AudioSource _audi;
    public GameObject audioDead;
    float _life;
    public float maxLife;

    public GameObject death;

    Player myPlayer;
    public void initialize(Player player)
    {
        myPlayer = player;
    }
    void Start()
    {
        _audi = GetComponent<AudioSource>();
        _life = maxLife;
    } 

    public void ActivarParticulas()
    {
        if(myPlayer != null)
        {
            ParticleSystem dust = GetComponentInChildren<ParticleSystem>();
            dust.Play();
        }
    }   
    public void TakeDmg(float dmg)
    {
        _life -= dmg;
        _audi.Play();
        ActivarParticulas();
        if (_life <=0)
        {
            Instantiate(audioDead);
            death.SetActive(true);
            Destroy(myPlayer);
            Destroy(this);
        }
    }
    public void MoreLife(float more)
    {
        _life += more;
        if (_life > maxLife)
        {
            _life = maxLife;

        }
    }

    public float Life
    {
        get { return _life; }
    }
}
