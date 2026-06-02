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
                data.cardDmg = 15f + PlayerBridgeData.Instance.dmgBoost + 3; 
                data.cardId = 0;
                data.cardEffect = "SPIRIT SPELL: +I MANA";
                break;
            case 1:
                data.cardName = "Spirit wind";
                data.manaCost = 1;
                data.cardDmg = 20f + PlayerBridgeData.Instance.dmgBoost + 3; 
                data.cardId = 1;
                data.cardEffect = "SPIRIT SPELL: +I MANA";
                break;
            case 2:
                data.cardName = "Spirit storm";
                data.manaCost = 3;
                data.cardDmg = 30f + PlayerBridgeData.Instance.dmgBoost + 3; 
                data.cardId = 2;
                data.cardEffect = "SPIRIT SPELL: RANDOM MANA";
                break;
            case 3:
                data.cardName = "Dark hole";
                data.manaCost = 10;
                data.cardDmg = 100f;
                data.cardId = 3;
                data.cardEffect = "STRONGEST MAGE ATTACK";
                break;
            case 4:
                data.cardName = "Spirit arrow";
                data.manaCost = 4;
                data.cardDmg = 35f + PlayerBridgeData.Instance.dmgBoost + 3; 
                data.cardId = 4;
                data.cardEffect = "SPIRIT SPELL: +I MANA";
                break;
            case 5:
                data.cardName = "Eye of the beholder";
                data.manaCost = 5;
                data.cardDmg = 60f + PlayerBridgeData.Instance.dmgBoost + 3; 
                data.cardId = 5;
                data.cardEffect = "EYE OF THE BEHOLDER: LIFEDRAIN";
                break;
            case 6:
                data.cardName = "Fairy potion";
                data.manaCost = 6;
                data.cardDmg = 10f + PlayerBridgeData.Instance.dmgBoost + 3; 
                data.cardId = 6;
                data.cardEffect = "FAIRY SPELL: DRAW A CARD";
                break;
            case 7:
                data.cardName = "Fairy wand";
                data.manaCost = 4;
                data.cardDmg = 10f + PlayerBridgeData.Instance.dmgBoost + 3; 
                data.cardId = 7;
                data.cardEffect = "FAIRY SPELL: DRAW A CARD";
                break;
            case 8:
                data.cardName = "Fireball";
                data.manaCost = 5;
                data.cardDmg = 60f + PlayerBridgeData.Instance.dmgBoost + 3; 
                data.cardId = 8;
                data.cardEffect = "FIREBALL: BURN (BONUS DMG)";
                break;
            case 9:
                data.cardName = "Crystal golem";
                data.manaCost = 7;
                data.cardDmg = 75f + PlayerBridgeData.Instance.dmgBoost + 3; 
                data.cardId = 9;
                data.cardEffect = "GOLEM: STUN (BONUS DMG)";
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