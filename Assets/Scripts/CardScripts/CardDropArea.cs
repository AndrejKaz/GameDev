using UnityEngine;
using UnityEngine.EventSystems;

public class CardDropArea : MonoBehaviour
{
    public DeckManager deckManager;
    public EnemyScript enemyScript;
    public HandView handView;
    public PlayerScript playerScript;

    //Get the card data and do damage now
    public void CardDrop()
    {
    
    if (CardDrag.draggedCard == null) return;

    CardContainerData cardData = CardDrag.draggedCard.GetComponent<CardContainerData>();

    if (cardData != null)
        {

            if(cardData.manaCost > playerScript.manaCounter)
            {
                print("Card has higher mana");
            }
            else
            {
                enemyScript.enemyHP -= cardData.cardDmg;
                playerScript.manaCounter -= cardData.manaCost;
                print("Card name: " + cardData.cardName);
                print("Enemy HP: " + enemyScript.enemyHP);
                print("Card mana played: " + cardData.manaCost);

                //Remove card from hand before destroying it
                handView.RemoveCard(CardDrag.draggedCard.gameObject);
                Destroy(CardDrag.draggedCard.gameObject);
            
            }
        }
    }

}
