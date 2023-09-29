using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyScriptableObject[] enemyScriptableObjects;
    public EnemyScriptableObject selectedSO;
    public EnemyScriptableObject selectedSOTank;
    public float timeInterval;
    public bool randomizeTimes;
    public float minTime;
    public float maxTime;
    public Transform[] columns;
    public int selectedColumns;
    //public GameObject gameSkor;
   /*[HideInInspector] */public GameObject[] zombie;
    

    public void SpawnZombies ()
    {
        StartCoroutine(ZombieSpawn());
        GameObject skorgame = GameObject.FindWithTag("skor");
        
    }

    public IEnumerator ZombieSpawn()
    {
        timeInterval = randomizeTimes ? Random.Range(minTime, maxTime) : timeInterval;

        yield return new WaitForSeconds(timeInterval);
        //Choose zombie
        selectedSO = enemyScriptableObjects[Random.Range(0, enemyScriptableObjects.Length)];
        //selectedSO = zombieScriptableObjects[0];

        //Spawn zombies
        int columnID = Random.Range(0, columns.Length);
        //for (int i  =0; i<zombie.Length; i++) { 
        GameObject zombie = Instantiate(selectedSO.EnemyDefault, columns[columnID]);

        zombie.GetComponent<EnemyController>().thisEnemySO = selectedSO;

        zombie.transform.SetParent(columns[columnID]);
        zombie.transform.position = new Vector3(0, 0, -1);
        zombie.transform.localPosition = new Vector3(0, 0, -1);
        //zombie.AddComponent
        //}
        //if (selectedSO.zombieAccessory != null)
        //{
        //    GameObject accessory = Instantiate(selectedSO.zombieAccessory, zombie.transform);
        //    zombie.GetComponent<ZombieController>().accessory = accessory;
        //    zombie.GetComponent<ZombieController>().zombieAccessories = accessory.GetComponent<ZombieAccessoriesManager>();
        //    zombie.GetComponent<ZombieController>().zombieAccessories.accessoryHealth = selectedSO.accessoryHealth;
        //    zombie.GetComponent<ZombieController>().zombieAccessories.accessoryHealthCurrent = selectedSO.accessoryHealth;
        //if (gameSkor.GetComponent<TextMeshProUGUI>().text == "3")
        //{

        //    GameObject Tank = Instantiate(selectedSO.zombieDefault, columns[columnID]);
        //        Debug.Log("Tank spawn");

        //    Tank.GetComponent<ZombieController>().thisZombieSO = selectedSO;

        //    Tank.transform.SetParent(columns[columnID]);
        //    Tank.transform.position = new Vector3(0, 0, -1);
        //    Tank.transform.localPosition = new Vector3(0, 0, -1);

        //    }
        StartCoroutine(ZombieSpawn());
    }
   
    
}
