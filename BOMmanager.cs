using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOMmanager : MonoBehaviour
{
    public GameObject ledakan;
    public Transform musuh;
    public void duarr()
    {
        ledakan.SetActive(true);
        //Instantiate(ledakan,musuh) ;
        Debug.Log("duarrrrrr");
    }
}
