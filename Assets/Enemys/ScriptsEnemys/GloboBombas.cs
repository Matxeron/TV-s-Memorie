using System.Collections;
using UnityEngine;

public class GloboBombas : MonoBehaviour
{
    //TP2 Marques Polich
    public Transform puntoA;
    public Transform puntoB;
    public Transform destinoActual;
    public float distanciaUmbral = 1f;  // Distancia umbral para cambiar de destino
    public float velocidadAgente = 3f;
    public GameObject bullet;
    public Transform positionSp;
    public Transform target;
    void Start()
    {
        StartCoroutine(Atack());
        destinoActual = puntoA;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinoActual.position, Time.deltaTime * velocidadAgente);
        if (Vector3.Distance(transform.position, destinoActual.position) < distanciaUmbral)
        {
            destinoActual = (destinoActual == puntoA) ? puntoB : puntoA;
        }
    }
IEnumerator Atack()
        {
            while(true)
            {       
            Instantiate(bullet, positionSp.position, positionSp.rotation);
            yield return new WaitForSeconds(2f);
            }
        }
    }
