using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManagerCollider : MonoBehaviour
{
    public GameObject plant;
    public bool isOccupied = false;
    SoldierManager cekOccupied;
    public void update()
    {
        if (plant != GameObject.FindGameObjectWithTag("soldier1"))
        {
            plant = null;
            isOccupied = false;
            Debug.Log("Nullllllllll");
        }
        
    }
    void OnMouseOver()
    {
        foreach (CardManager item in GameObject.FindObjectsOfType<CardManager>())
        {
            item.colliderName = this.GetComponent<SlotsManagerCollider>();
            item.isOverCollider = true;
        }

      
        if (plant == null)
        {
            if (GameObject.FindGameObjectWithTag("soldier") != null)
            {
                plant = GameObject.FindGameObjectWithTag("soldier");
                plant.transform.SetParent(this.transform);
                Vector3 pos = new Vector3(0, 0, -1);
                plant.transform.position = new Vector3(0, 0, -1);
                plant.transform.localPosition = pos;
                Debug.Log("ini slaha");
               //plant = transform.GetChild(0).gameObject;
             
            }
           
            
        }
        else
        {
            isOccupied = false;

        }

        //if (plant != GameObject.FindGameObjectWithTag("soldier1"))
        //{
        //    plant = null;
        //    isOccupied = false;
        //    Debug.Log("Nullllllllgggggggl");
        //    return;
        //}
        //{

        //}
        ////if (plant=mis)
        ////{
        ////    isOccupied = false;
        ////}
    }

    private void OnMouseExit()
    {
      /*  Destroy(plant)*/;
    }
}
