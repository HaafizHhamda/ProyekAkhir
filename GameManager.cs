using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static string coinPrefsName = "Coins_Player";

    public TMP_Text sunDisp;
    public int startingSunAmnt;
    public int SunAmount = 0;

    public int PointMenang;
    public GameObject spawnMusuh;
    //public GameObject decorativeZombies;

    public Transform cardSlotsHolder;

    public EnemyManager enemyManager;
    EnemyController skor_;

    public Animator cameraPan;
    public GameObject karakter1;

    //public Image Winnotif;

    public static int currentAmount;
    public int preCurrentAmount = -1;

    //public TMP_Text coinDisplay;
    
    private void Start()
    {
        currentAmount = PlayerPrefs.GetInt(coinPrefsName);

        //coinDisplay.SetText(currentAmount + "");

        CardManager.isGameStart = false;
        AddSun(startingSunAmnt);
       
        //PointMenang = 0;
    }

	public void Update()
	{
		if (preCurrentAmount != currentAmount)
		{
            preCurrentAmount = currentAmount;
            //coinDisplay.SetText(currentAmount + "");
        }
	}

	public void StartMatch()
	{
        cameraPan.SetTrigger("PanToPlants");
        LeanTween.moveLocalX(karakter1, 1421, 1.25f).setEaseOutBounce().setDelay(1f);
        CardManager.isGameStart = true;
        RefreshAllPlantCards();
        enemyManager.SpawnZombies();
       
    }

    public void AddSun(int amnt)
    {
        SunAmount += amnt;
        sunDisp.text = "" + SunAmount;
    }

    public void DeductSun(int amnt)
    {
        SunAmount -= amnt;
        sunDisp.text = "" + SunAmount;
    }

    public void RefreshAllPlantCards()
	{
        foreach (Transform card in cardSlotsHolder)
        {
            try
            {
                card.GetComponent<CardManager>().StartRefresh();
            }
            catch (System.Exception)
            {
                Debug.LogError("Card does not contain CardManager script!");
            }
        }
    }

    public static void IncrementCoins(int value)
	{
        currentAmount += value;
    }

	public void OnApplicationQuit()
	{
        PlayerPrefs.SetInt(coinPrefsName, currentAmount);
	}
}
