using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoldierCardManager : MonoBehaviour
{
    [Header("Cards Parameters")]
    public int amtOfCards;
    public SoldierCardScriptableObject[] plantCardSO;
    public GameObject cardPrefab;
    public Transform cardHolderTransform;

    [Header("Plant Parameters")]
    public List<GameObject> plantCards;
    public float cooldown;
    public int cost;
    public Texture soldierIcon;

    public Transform selectionTransform;
    public GameObject selectionCardPrefab;

    public List<int> selectedIndexes;
    public List<GameObject> selectionCards;

    public int minCardAllowed;
    public Button letsRockButton;

    
    private void Start()
	{
        mulaiGame();
    }
     
    private void mulaiGame()
    {
        amtOfCards = plantCardSO.Length;
        plantCards = new List<GameObject>();

        selectionCards = new List<GameObject>();

        for (int i = 0; i < amtOfCards; i++)
        {
            AddPlantCardSelection(i);
        }
    }
	public void Update()
	{
        letsRockButton.interactable = plantCards.Count >= minCardAllowed;
	}



    public void AddPlantReference(SoldierCardScriptableObject plantSO, CardManager parentCard = default)
	{
        AddPlantCard(new List<SoldierCardScriptableObject>(plantCardSO).IndexOf(plantSO), parentCard);
	}

    public void AddPlantCard(int index, CardManager parentCard = default)
    {
        if (selectedIndexes.Contains(index))
		{
            //Remove card
            int indexPos = selectedIndexes.IndexOf(index);

            GameObject tempRef = plantCards[indexPos];

            plantCards.Remove(tempRef);

            Destroy(tempRef);

            selectedIndexes.Remove(index);
        }
		else
		{
            selectedIndexes.Add(index);

            GameObject card = Instantiate(cardPrefab, cardHolderTransform);
            CardManager cardManager = card.GetComponent<CardManager>();

            cardManager.plantCardScriptableObject = plantCardSO[index];
            cardManager.plantSprite = plantCardSO[index].plantSprite;
            cardManager.UI = GameObject.FindGameObjectWithTag("Canvas");

            plantCards.Add(card);

            //Getting Variables
            soldierIcon = plantCardSO[index].plantIcon;
            cost = plantCardSO[index].cost;
            cooldown = plantCardSO[index].cooldown;

            cardManager.parentCard = parentCard;
            cardManager.soldierCardManager = this;

            Debug.Log("Name : " + parentCard.gameObject.name);

            //Updating UI
            card.GetComponentInChildren<RawImage>().texture = soldierIcon;
            card.GetComponentInChildren<TMP_Text>().text = "" + cost;
        }
    }

    public void AddPlantCardSelection(int index)
    {
        GameObject card = Instantiate(selectionCardPrefab, selectionTransform);
        CardManager cardManager = card.GetComponent<CardManager>();

        cardManager.plantCardScriptableObject = plantCardSO[index];
        cardManager.plantSprite = plantCardSO[index].plantSprite;
        cardManager.UI = GameObject.FindGameObjectWithTag("Canvas");

        selectionCards.Add(card);

        //Getting Variables
        soldierIcon = plantCardSO[index].plantIcon;
        cost = plantCardSO[index].cost;
        cooldown = plantCardSO[index].cooldown;

        cardManager.soldierCardManager = this;

        //Updating UI
        card.GetComponentInChildren<RawImage>().texture = soldierIcon;
        card.GetComponentInChildren<TMP_Text>().text = "" + cost;
    }
}
