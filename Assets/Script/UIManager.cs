using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //TP2 Marques

    public Player playerRef;
    public Slider lifeSlider;
   
   
    public Slider empathySlider;


    public TMP_Text bullets;
    public TMP_Text charger;
    public TMP_Text Weapon;

    void Update()
    {
        lifeSlider.value = playerRef.lifeRef;
        empathySlider.value = playerRef.empathyRef;
        if (playerRef.indexGun!=0)
        {
            bullets.text = "Balas:" + playerRef.inventario.items[playerRef.indexGun].gun.GetComponent<NormalGun>().bulletCount;
            charger.text = "(R)ecargas: " + playerRef.inventario.items[playerRef.indexGun].gun.GetComponent<NormalGun>().chargeCount;
            Weapon.text = playerRef.inventario.items[playerRef.indexGun].name;
        }
        
    }

    
} 

