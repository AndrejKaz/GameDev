using UnityEngine;
using UnityEngine.EventSystems;

public class CardDropArea : MonoBehaviour
{
    public DeckManager deckManager;
    public EnemyScript enemyScript;
    public HandView handView;

    //Get the card data and do damage now
    public void CardDrop()
    {
    
    if (CardDrag.draggedCard == null) return;

    CardContainerData cardData = CardDrag.draggedCard.GetComponent<CardContainerData>();

    if (cardData != null)
        {
            enemyScript.enemyHP -= cardData.cardDmg;
            print("Card name: " + cardData.cardName);
            print("Enemy HP: " + enemyScript.enemyHP);

            // Remove from hand BEFORE destroying
            handView.RemoveCard(CardDrag.draggedCard.gameObject);
            Destroy(CardDrag.draggedCard.gameObject);
        }
    }

}
