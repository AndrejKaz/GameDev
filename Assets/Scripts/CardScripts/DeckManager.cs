using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEngine;


public class DeckManager : MonoBehaviour
{
    [SerializeField] GameObject myDeck;
    [SerializeField] public GameObject cardPrefab;
    public List<GameObject> deckList = new ();
    public bool deckExists = false;
    public int cardsInDeck = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(myDeck == null) return;

        if (!deckExists)
        {
            CardsOnLoad();
            deckExists = true;
        }
        //SetCardData
        if(deckList.Count == cardsInDeck) DeckShuffle();
    }

    void Update()
    {
        for(int i = 0; i < 50; i++)
        {
            print(deckList[i].GetComponent<CardContainerData>().cardName);
        }
    }

    //Create all 50 cards and place them in the deck
    private void CardsOnLoad()
    {
        for(int i = 0; i < cardsInDeck; i++)
        {
            GameObject deckCard = Instantiate(cardPrefab, myDeck.transform.position, Quaternion.identity);
            deckCard.transform.SetParent(myDeck.transform, true);

            //Get the card datat
            CardContainerData cardData = deckCard.GetComponent<CardContainerData>();

            if(deckCard != null) SetCardData(cardData, i);            

            deckList.Add(deckCard);
        }
    } 

    private void SetCardData(CardContainerData data, int index)
    {
        //SetCardID data
        switch (index % 5) 
        {
            case 0:
                data.cardName = "Spirit axe";
                data.manaCost = 2;
                data.cardDmg = 3.0f;
                data.cardId = 0;
                break;
            case 1:
                data.cardName = "Spirit wind";
                data.manaCost = 1;
                data.cardDmg = 1.5f;
                data.cardId = 1;
                break;
            case 2:
                data.cardName = "Spirit storm";
                data.manaCost = 4;
                data.cardDmg = 5.0f;
                data.cardId = 2;
                break;
            case 3:
                data.cardName = "Dark hole";
                data.manaCost = 10;
                data.cardDmg = 20.0f;
                data.cardId = 3;
                break;
            case 4:
                data.cardName = "Spirit arrow";
                data.manaCost = 6;
                data.cardDmg = 8.5f;
                data.cardId = 4;
                break;
            case 5:
                data.cardName = "Eye of the beholder";
                data.manaCost = 5;
                data.cardDmg = 7f;
                data.cardId = 5;
                break;
            case 6:
                data.cardName = "Fairy boots";
                data.manaCost = 4;
                data.cardDmg = 3f;
                data.cardId = 6;
                break;
            case 7:
                data.cardName = "Fairy wings";
                data.manaCost = 7;
                data.cardDmg = 12f;
                data.cardId = 7;
                break;
            case 8:
                data.cardName = "Blue flame";
                data.manaCost = 5;
                data.cardDmg = 6.5f;
                data.cardId = 8;
                break;
            case 9:
                data.cardName = "Crystal golem";
                data.manaCost = 9;
                data.cardDmg = 17f;
                data.cardId = 9;
                break;
        }
    }

    private void DeckShuffle()
    {
        int rand = UnityEngine.Random.Range(0, cardsInDeck);

        for(int i = 0; i < cardsInDeck; i++)
        {
            GameObject temp = deckList[i];
            deckList[i] = deckList[rand];
            deckList[rand] = temp;
        }
    }
}
