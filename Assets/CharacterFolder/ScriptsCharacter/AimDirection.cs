using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimDirection : MonoBehaviour
{
    //TP2 VintarValentin
    Camera cameraCam;
    

    public void ForwardShooting(Camera cam)
    {
        cameraCam= cam;

        if (Input.GetMouseButton(1))
        {
            Vector3 positionOnSceen = cameraCam.WorldToViewportPoint(transform.position);
            Vector3 mouseOnScreen = (Vector2)cameraCam.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = mouseOnScreen - positionOnSceen;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        }
    }
}
