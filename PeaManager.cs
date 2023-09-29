using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaManager : MonoBehaviour
{
    public float damage;
    public GameObject meledak; 
    public GameObject senjataPea;
    //private Collider2D colisder;
    string a;

    private void Start()
    {
         a = senjataPea.name;
        Debug.Log(senjataPea.name);
    }


    private void OnTriggerEnter2D(Collider2D collider2D)// deteksi tembakan
    {


        //for (a=0; a<senjataPea.Length; a++) {
        // colisder = collider2;
            if (collider2D.gameObject.tag == "Zombie" && a == "Pea(Clone)")// senjata 1&2 peluru biasa
            {
               collider2D.gameObject.GetComponent<EnemyController>().DealDamage(damage);
               Debug.Log("kena");
               Debug.Log(senjataPea.name);
               Destroy(this.gameObject);
               }

            if (collider2D.gameObject.tag == "Zombie"&& a== "peluru(Clone)")// senjata 2 // sniper
            {
                collider2D.gameObject.GetComponent<EnemyController>().DealDamage(damage);
                Debug.Log("kena1");
                Destroy(this.gameObject);
            }
                
            if (collider2D.gameObject.tag == "Zombie" && a== "Bom(Clone)")// senjata 3// bom
              {
            //Instantiate(ledakan,musuh);
             collider2D.gameObject.GetComponent<EnemyController>().DealDamage(damage);
                Debug.Log("12345");
                
                Destroy(this.gameObject, 0.5f);
                
                Instantiate(meledak, collider2D.transform);

                
                
                //Destroy(this.meledak, 10f);
            }
       
            if (collider2D.gameObject.tag == "Zombie"&& a== "Bazoka(Clone)")// senjata 4//bozoka
            {
                collider2D.gameObject.GetComponent<EnemyController>().DealDamage(damage);
                Destroy(this.gameObject, 0.5f);
                Instantiate(meledak, collider2D.transform);
            
            }
    }
}
