using Unity.VisualScripting;
using UnityEngine;

public class CardDropArea : MonoBehaviour
{
    /*[===References===]*/
    public DeckManager deckManager;
    public EnemyScript enemyScript;
    public HandView handView;
    public PlayerScript playerScript;
    public TurnCounter turnCounter;
    public EnemyBridgeData enemyBridgeData;

    public void CardDrop()
    {
        if (CardDrag.draggedCard == null) return;
        
        CardContainerData cardData = CardDrag.draggedCard.GetComponent<CardContainerData>();        

        if (cardData.manaCost > playerScript.manaCounter)
        {
            print("Not enough mana!");
            return;
        }


        //For some reason bcs of Fiary Wings effect you need to remove the cards again 
        handView.RemoveCard(CardDrag.draggedCard.gameObject);
        Destroy(CardDrag.draggedCard.gameObject);

        playerScript.manaCounter -= cardData.manaCost;

        if (enemyScript.enemyHP >= 100f) enemyScript.enemyHP -= cardData.cardDmg / 10f + (enemyBridgeData.BridgeEnemyATK / 2);
        enemyScript.enemyHP -= cardData.cardDmg / 10f + (enemyBridgeData.BridgeEnemyATK / 2);

        CardEffect(cardData.cardName);

        print(enemyScript.enemyHP);
       
        handView.RemoveCard(CardDrag.draggedCard.gameObject);
        Destroy(CardDrag.draggedCard.gameObject);
    
        print("Card name: " + cardData.cardName);
    }

    //Card effect functions
    private void SpiritAxe()
    {
        playerScript.manaCounter += 2;
    }
    private void SpiritWind()
    {
        playerScript.manaCounter += 2;
    }
    private void SpiritStorm()
    {
        playerScript.manaCounter += 3;
    }
    private void SpiritArrow()
    {
        int rand = Random.Range(1, 2);
        float critDmg = Random.Range(5f, 10f);
        if (rand == 1) enemyScript.enemyHP -= critDmg;
        playerScript.manaCounter += 2;
    }
    private void EyeOfTheBeholder()
    {
        float lifeSteal = enemyScript.EnemyDefOnHit();
        playerScript.playerHP += lifeSteal;
        turnCounter.turnCounter += 2;
    }
    private void FairyPotion()
    {
        turnCounter.turnCounter += 2;
        playerScript.manaCounter += 6;
    }
    private void FairyWand()
    {
        handView.DrawCard();
        handView.DrawCard();
        playerScript.manaCounter += 4;
    }

    private void CardEffect(string cardName)
    {
        switch (cardName)
        {   
            case "Spirit wind": SpiritWind(); break; 
            case "Fairy potion": FairyPotion(); break;
            case "Eye of the beholder": EyeOfTheBeholder(); break;
            case "Spirit arrow": SpiritArrow(); break;
            case "Spirit storm": SpiritStorm(); break;
            case "Fairy wand": FairyWand(); break;
            case "Spirit axe": SpiritAxe(); break;
        }
    }
}