using System;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(myDeck == null) return;

        if (!deckExists)
        {
            CardsOnLoad();
            deckExists = true;
        }

        if(deckList.Count == 50) DeckShuffle();
    }


    //Create all 50 cards and place them in the deck
    private void CardsOnLoad()
    {
        for(int i = 0; i < 50; i++)
        {
            GameObject deckCard = Instantiate(cardPrefab, myDeck.transform.position, Quaternion.identity);
            deckCard.transform.SetParent(myDeck.transform, true);
            deckList.Add(deckCard);
        }
    } 

    private void DeckShuffle()
    {
        int rand = UnityEngine.Random.Range(0, 50);

        for(int i = 0; i < 50; i++)
        {
            GameObject temp = deckList[i];
            deckList[i] = deckList[rand];
            deckList[rand] = temp;
        }
    }
}
