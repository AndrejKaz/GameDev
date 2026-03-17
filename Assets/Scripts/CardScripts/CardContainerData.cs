using UnityEngine;

public class CardContainerData : MonoBehaviour
{
    public int manaCost;
    public float cardDmg;
    public int cardId;
    public string cardName;
    public SpriteRenderer spriteRenderer;

    public void Awake()
    {
        if(spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
