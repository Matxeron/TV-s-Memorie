using UnityEngine;
using UnityEngine.UI;

public class Mina : MonoBehaviour
{

    public delegate void delegates();
    delegates Explocion;
    public Image imageTimer;
    public Canvas canvas;
    public float timeS;
    public AudioSource audioSource;
    public GameObject explosion;
    public GameObject instan;
    bool explote = false;

    private void Update()
    {

        if (explote == true)
        {
            Timer();
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 3)
        {
           explote= true;
            canvas.gameObject.SetActive(true);
        }
      
    }

    void Timer()
    {

        timeS += Time.deltaTime;
        imageTimer.fillAmount = timeS;

        if (timeS > 1)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(instan, transform.position, transform.rotation);
            ParticleSystem exp = GetComponentInChildren<ParticleSystem>();
            exp.Play();
            audioSource.Play();
            Destroy(gameObject, exp.main.duration);
            explote= false;
        }

     
    }

  
}
