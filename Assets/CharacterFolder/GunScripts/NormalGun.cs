using System.Collections;
using UnityEngine;

public class NormalGun : GunsAbs
{
    //TP2 Polich

    public string bulletCount;
    public string chargeCount;
    public GameObject positionSp;


    protected override void Update()
    {
        base.Update();
        bulletCount = "" + _bulletCount;
        chargeCount = "" + charge;
    }

    protected override IEnumerator ShootingAuto()
    {        
            Instantiate(bullet, positionSp.transform.position, positionSp.transform.rotation);
            bullet.GetComponent<EnemyBullet>().Initialize(maskAtack);
            bullet.GetComponent<EnemyBullet>().myDmg = gunDmg;
            _bulletCount--;
            yield return null;        
    }

    protected override IEnumerator ShootingBurst()
    {

      
            Instantiate(bullet, positionSp.transform.position, positionSp.transform.rotation);
            bullet.GetComponent<EnemyBullet>().Initialize(maskAtack);
            bullet.GetComponent<EnemyBullet>().myDmg = gunDmg;
            _bulletCount--;
        yield return null;


    }
}
