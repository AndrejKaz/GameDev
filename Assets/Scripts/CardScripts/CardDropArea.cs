using UnityEngine;

public class CardDropArea : MonoBehaviour
{
    /*[===References===]*/
    public DeckManager deckManager;
    public EnemyScript enemyScript;
    public HandView handView;
    public PlayerScript playerScript;
    public TurnCounter turnCounter;

    public void CardDrop()
    {
        if (CardDrag.draggedCard == null) return;
        
        CardContainerData cardData = CardDrag.draggedCard.GetComponent<CardContainerData>();
        if (cardData == null) return;

        if (cardData.manaCost > playerScript.manaCounter)
        {
            print("Not enough mana!");
            return;
        }

        playerScript.manaCounter -= cardData.manaCost;

        CardEffect(cardData.cardName);

        if (enemyScript.enemyHP >= 100f) enemyScript.enemyHP -= cardData.cardDmg;
        enemyScript.enemyHP -= (cardData.cardDmg - enemyScript.EnemyDefOnHit());

       
        handView.RemoveCard(CardDrag.draggedCard.gameObject);
        Destroy(CardDrag.draggedCard.gameObject);
    
        print("Card name: " + cardData.cardName);
    }

    //Card effect functions
    private void FairyBoots()
    {
        turnCounter.turnCounter += 2;
        playerScript.manaCounter += 2;
    }

    private void EyeOfTheBeholder()
    {
        float lifeSteal = enemyScript.EnemyDefOnHit();
        playerScript.playerHP += lifeSteal;
    }

    private void SpiritArrow()
    {
        int rand = Random.Range(1, 2);
        if (rand == 1) enemyScript.enemyHP -= 5f;
    }

    private void FairyWings()
    {
        for (int i = 0; i < 2; i++)
            handView.DrawCard();
    }

    private void CardEffect(string cardName)
    {
        switch (cardName)
        {
            case "Fairy boots":      
                FairyBoots();       
                break;
            case "Eye of the beholder": 
                EyeOfTheBeholder(); 
                break;
            case "Spirit arrow":    
                SpiritArrow();      
                break;
            case "Fairy wings":      
                FairyWings();       
                break;
        }
    }
}