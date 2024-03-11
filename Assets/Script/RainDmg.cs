using System.Collections;
using UnityEngine;

public class RainDmg : MonoBehaviour
{
    [SerializeField]
    int DMG;
    [SerializeField]
    float time;

    private void OnTriggerEnter(Collider other)
    {
        IDamagable x = other.GetComponent<IDamagable>();
        if (other.gameObject.layer == 3 && x != null)
        {
            StartCoroutine(DMGRain(x));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IDamagable x = other.GetComponent<IDamagable>();
        

        if (other.gameObject.layer == 3 && x != null)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator DMGRain(IDamagable y)
    {

        while(true) 
        {
            y.TakeDmg(DMG);
        yield return new WaitForSeconds(time);
        }

    }
}
