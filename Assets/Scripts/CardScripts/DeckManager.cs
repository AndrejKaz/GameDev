using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class DeckManager : MonoBehaviour
{
    /*[===Game Objects===]*/
    [SerializeField] GameObject myDeck;
    [SerializeField] public GameObject cardPrefab;
    public List<GameObject> deckList = new();

    /*[===References===]*/
    [SerializeField] private Sprite[] cardSprites;

    /*[===Variables===]*/
    public bool deckExists = false;
    public int cardsInDeck = 50;

    void Start()
    {
        if (myDeck == null) return;

        if (!deckExists)
        {
            CardsOnLoad();
            deckExists = true;
        }
        DeckShuffle();
    }

    private void CardsOnLoad()
    {
        for (int i = 0; i < cardsInDeck; i++)
        {
            GameObject deckCard = Instantiate(cardPrefab, myDeck.transform.position, Quaternion.identity);
            deckCard.transform.SetParent(myDeck.transform, true);

            CardContainerData cardData = deckCard.GetComponent<CardContainerData>();

            if (cardData != null)
            {
                SetCardData(cardData, i);

                if (cardData.spriteRenderer != null) cardData.spriteRenderer.sprite = cardSprites[cardData.cardId];
            }

            deckCard.transform.localScale = new Vector3(1,1.5f,1);
            deckList.Add(deckCard);
        }
    }

    private void SetCardData(CardContainerData data, int index)
    {
        switch (index % 10)
        {
            case 0:
                data.cardName = "Spirit axe";
                data.manaCost = 1;
                data.cardDmg = 350f;
                data.cardId = 0;
                break;
            case 1:
                data.cardName = "Spirit wind";
                data.manaCost = 1;
                data.cardDmg = 400f;
                data.cardId = 1;
                break;
            case 2:
                data.cardName = "Spirit storm";
                data.manaCost = 3;
                data.cardDmg = 505f;
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
                data.manaCost = 4;
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
                data.cardName = "Fairy Potion";
                data.manaCost = 6;
                data.cardDmg = 3f;
                data.cardId = 6;
                break;
            case 7:
                data.cardName = "Fairy wand";
                data.manaCost = 4;
                data.cardDmg = 3.5f;
                data.cardId = 7;
                break;
            case 8:
                data.cardName = "Fireball";
                data.manaCost = 5;
                data.cardDmg = 7.0f;
                data.cardId = 8;
                break;
            case 9:
                data.cardName = "Crystal golem";
                data.manaCost = 7;
                data.cardDmg = 12.3f;
                data.cardId = 9;
                break;
        }
    }

    private void DeckShuffle()
    {
        for (int i = 0; i < cardsInDeck; i++)
        {
            int rand = UnityEngine.Random.Range(0, cardsInDeck);
            Swap(i, rand);
        }
    }

    private void Swap(int i1, int i2)
    {
        GameObject temp = deckList[i1];
        deckList[i1] = deckList[i2];
        deckList[i2] = temp;
    }
}