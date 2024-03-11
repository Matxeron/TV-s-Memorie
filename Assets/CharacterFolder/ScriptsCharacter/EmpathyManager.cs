using System;
using UnityEngine;

public class EmpathyManager : MonoBehaviour
{
    //TP2 Vintar
    [SerializeField, Range(0, 100)]
    float _empathy;

    public float maxEmpathy;

    float _timetoRest = 1.2f;
    float _timeTranscurred;

    public Player _playerReff;
    float _speedRef;
    public GameObject death;
    public GameObject audioDead;
    
    
 
    void Start()
    {
        _empathy = maxEmpathy;
        _speedRef = _playerReff.speed;
    }

    private void Update()
    {
       MecanicaEmpatia();   
    }

    public void RestEmpathy()
    {
        _timeTranscurred += Time.deltaTime;
        if (_timeTranscurred > _timetoRest)
        {
            _empathy--;
            
            _timeTranscurred = 0;
        }
    }

    public void PlusEmpathy(float empathy)
    {
        _empathy += empathy;
        if (_empathy >= maxEmpathy)
        {
            _empathy = maxEmpathy;
        }
    }

   


    void MecanicaEmpatia()
    {
        if (_empathy <= 75 && _empathy >= 50)
        {
            _playerReff.movement.speed = _speedRef / 1.5f;
        }
        else if (_empathy <= 50 && _empathy >= 25)
        {
            _playerReff.movement.speed = _speedRef / 3f;
        }
        else if (_empathy <=25 && _empathy >= 0)
        {
            _playerReff.movement.speed = _speedRef /5f;
        }
        else if (_empathy <=0)
        {
                Instantiate(audioDead);
                death.SetActive(true);
                Destroy(_playerReff);
                Destroy(this);
            
        }
        else
        {
            _playerReff.movement.speed = _speedRef;
        }
    }

    public float Empathy
    {
        get { return _empathy; }
    }



}
