using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided death!");

        if (collision.tag == "Zombie")
        {
            SceneManager.LoadScene("kalah");
            Debug.Log("Died!");
        }
    }
}
