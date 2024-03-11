
using UnityEngine;

public abstract class EntityEnemys : MonoBehaviour, IDamagable
{
    //TP2 Marques
    [SerializeField]
    protected float _life = 100;
    [SerializeField]
    protected int _bulletCount;

    [SerializeField]
    protected string[] text; 

  
    public virtual void TakeDmg(float dmg)
    {
        _life -= dmg;
        print(_life);
        if (_life <= 0)
        {
            Muerte();
        }
    }
    protected abstract void Muerte();   
    protected abstract void Atack();

    protected abstract void AudioEnemy();

}
