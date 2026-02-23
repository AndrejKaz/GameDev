using System.Collections.Generic;
using UnityEngine;

public class HandView : MonoBehaviour
{
    /*[===GAME-OBJECTS===]*/
    [SerializeField] GameObject hand;
    [SerializeField] GameObject deck;
    [SerializeField] GameObject card;

    /*[===VARIABLES===]*/
    private int handSize = 5;
    private List<GameObject> cards;

    void Start()
    {
        cards = new List<GameObject>();

        if (deck == null)
        {
            Debug.Log("Deck is missing");
            return;
        }

        DealHand();
    }

    public void DealHand(){
    
        float spacing = 1.2f;
        float totalWidth = (handSize - 1) * spacing;
        float startX = -totalWidth / 2f;

        for (int i = 0; i < handSize; i++)
        {
            float x = startX + i * spacing;
            GameObject cardInstance = Instantiate(card, new Vector3(x, -1f, 0), Quaternion.identity);
            cards.Add(cardInstance);
        }
    }
}