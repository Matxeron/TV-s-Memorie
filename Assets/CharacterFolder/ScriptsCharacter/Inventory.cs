using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    // public List<Item> items = new List<Item>();
   public  Dictionary<int , Item> items = new Dictionary< int, Item>();
 
   
        Item secundaria;
        Item principal;

    public int indexRef;
   
   
  public void cheak()
    {
        int Metralleta = 1;
        if (items.ContainsKey(Metralleta))
        {
            principal = items[Metralleta];
            indexRef= 1;
        }
        int Normal = 2;
        if (items.ContainsKey(Normal))
        {
            indexRef= 2;
            secundaria = items[Normal];
        }
    }
    public void TakeWeapon()
    {
        if (indexRef == 2)
        {
            if (principal.gun != null)
            {
                principal.gun.gameObject.SetActive(false);
                principal.equipped= false;
            }
            secundaria.gun.gameObject.SetActive(true);
            secundaria.equipped= true;
        }
        else if(indexRef == 1) 
        {
            if (secundaria.gun != null)
            {
                secundaria.gun.gameObject.SetActive(false);
                secundaria.equipped= false;
            }
            principal.equipped = true;
            principal.gun.gameObject.SetActive(true);
        }

    }
    public void changeWeapon()
    {
        if (secundaria.gun != null && principal.gun != null)
        {
            if (secundaria.equipped && !principal.equipped)
            {
                secundaria.gun.SetActive(false);
                secundaria.equipped = false;
                principal.gun.SetActive(true);
                principal.equipped = true;
                indexRef = 1;
            }
            else if (!secundaria.equipped && principal.equipped)
            {
                secundaria.gun.SetActive(true);
                secundaria.equipped = true;
                principal.gun.SetActive(false);
                principal.equipped = false;
                indexRef = 2;
            }
        }
    }

}


[System.Serializable]
public struct Item
{
    public GameObject gun;
    public string name;
    public bool equipped;
}