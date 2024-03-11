
using UnityEngine;

public class BossEvent : MonoBehaviour
{
    public delegate void MiEventoDelegate();

    public event MiEventoDelegate OnEvento;

    private void Start()
    {
        OnEvento = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
