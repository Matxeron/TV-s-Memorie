using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Controller : IAnimator
{
    
    //TP2 VintarValentin

    public Movement _movement;
    public Pause _pause;
    public GameObject canvas;
    public bool _ispaused = false;

    EmpathyManager _empathy;

    private Animator _animator;
    public float speed;

    public delegate void Interact();
    public Interact action;

    public NPCScript dialogo;
    Inventory inventory;
   

    public Controller (Movement movement, Pause pause, GameObject _canvas, EmpathyManager empathy, Animator _anim, float _speed, Inventory inventario)

    {
        _movement = movement;
        _pause = pause;
        canvas = _canvas;
        _empathy= empathy;
        _animator = _anim;
        speed = _speed;
        action = empty;
        inventory= inventario;
    }

    public void ArtificialOnTrigger()
    {
         dialogo.npcs.gameObject.SetActive(true);

          if (Input.GetKeyUp(KeyCode.E))
          {
             dialogo.dialogues();
              dialogo.reference = _empathy;
            
         }


    }
    public void ArtificialExit ()
    {
       dialogo.myDialogues.StopAllCoroutines();
       dialogo.panelDialogos.SetActive(false);
    }
    void empty()
    {

    }
    public void Artificialupdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        if (h != 0 || v != 0)
        {
            Caminar();
            _movement.move(h, v);
        }
        else
        {
            Idle();
            _movement.stop();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pused();
        }

        action();

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            inventory.changeWeapon();
        }
    }
    public void Pused()
    {
        float time;
        if (_ispaused == false)
        {
            _ispaused = true;
            time = 0;
            _pause.PausedGame(canvas, _ispaused, time);
            return;
        }
        else
        {
            _ispaused = false;
            time = 1;
            _pause.PausedGame(canvas, _ispaused, time);
        }
    }

    public void Caminar() 
    {
        _animator.SetBool("Walk",true);
        _animator.SetBool("Idle", false);
        _animator.SetFloat("Speed", speed);
    }
    public void Morir() { }
    public void Disparar () { }
    public void Idle()
    {
        _animator.SetBool("Idle", true);
        _animator.SetBool("Walk", false);
    }
    public void Stop () { } 
}
