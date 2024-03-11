using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CollectiblesMuseum : MonoBehaviour
{

    public GraphicRaycaster graphRay;
    private PointerEventData pointData;
    private List<RaycastResult> raycastResult;

    public Transform canvas;
    public GameObject objetoSelected;



    // Start is called before the first frame update
    void Start()
    {
        pointData = new PointerEventData(null);
        raycastResult= new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update()
    {
        Arrast();
    }


    void Arrast()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
        pointData.position = Input.mousePosition;
            graphRay.Raycast(pointData, raycastResult);
            if (raycastResult.Count > 0 )
            {
                if (raycastResult[0].gameObject.GetComponent<ItemsCol>())
                {
                    objetoSelected = raycastResult[0].gameObject;
                    objetoSelected.transform.SetParent(canvas);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
        pointData.position = Input.mousePosition;
            raycastResult.Clear();
            graphRay.Raycast(pointData,raycastResult);
            if (raycastResult.Count > 0)
            {
                foreach (var resultado in raycastResult)
                {
                    if (resultado.gameObject.tag == "Slot")
                    {
                        objetoSelected.transform.SetParent(resultado.gameObject.transform);
                        objetoSelected.transform.localPosition = Vector2.zero;
                    }
                }
            }
        }
    }

}
