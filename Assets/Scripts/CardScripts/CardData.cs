using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CardData : MonoBehaviour
{
    /*[===REFERENCES===]*/
    DeckManager deckManager;
    CardContainerData cardData;


    //Getting needed data from fixed arrays;
    /*[===VARIABLES===]*/    
    private int uniqueNumCards = 20;
    private int[] numberId;
    

    public void SetCardIdArr()
    {
        numberId = new int[uniqueNumCards];
    
        for (int i = 0; i < uniqueNumCards; i++)
        {
            numberId[i] = i;
        }
    }

    //Setting the data for the cards
    public void setData()
{
    for (int i = 0; i < uniqueNumCards; i++)
    {
        if (i == 2)
        {
            cardData.manaCost = 2;
            cardData.cardDmg = 3.00f;
            cardData.cardId = 5;
            cardData.cardName = "Fireball";
        }
    }
}
}
