using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAdd : MonoBehaviour
{
    public int myInt;
    public Item myGun;
    private void OnTriggerEnter(Collider other)
    {
        Inventory x = other.GetComponent<Inventory>();
        if (x != null)
        {
            x.items.Add(myInt, myGun);
            x.cheak();
            print("asdfas");
            x.indexRef = myInt;
            x.TakeWeapon();
        }
        Destroy(this.gameObject);
    }
}
