using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardData : MonoBehaviour
{
    /*[===VARIABLES===]*/
    [SerializeField] int manaCost;
    [SerializeField] string cardEffect;
    [SerializeField] float cardDmg;
    [SerializeField] int cardId;
    [SerializeField] string cardName;
    //Sprite render

    //I will have 19 unique cards, and 50 cards in total in my deck
    public void Start()
    {
        
    }


}
