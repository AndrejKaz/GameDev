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
    
    /*[===Variables===]*/
    [SerializeField] AudioClip dropClip;
    [SerializeField] AudioSource audioSource;

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

        audioSource.clip = dropClip;
        audioSource.Play();

        CardEffect(cardData.cardName);

        enemyScript.enemyHP -= cardData.cardDmg / 10f + (enemyBridgeData.BridgeEnemyATK / 2);
        enemyScript.slider.value = enemyScript.enemyHP;
       
        handView.RemoveCard(CardDrag.draggedCard.gameObject);
        Destroy(CardDrag.draggedCard.gameObject);
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
        int randomMana = Random.Range(1, 5);
        playerScript.manaCounter += randomMana;
    }
    private void SpiritArrow()
    {
        int rand = Random.Range(1, 2);
        float critDmg = Random.Range(8f, 10f);
        if (rand == 1) enemyScript.enemyHP -= critDmg;
        playerScript.manaCounter += 6;
    }
    private void EyeOfTheBeholder()
    {
        float lifeSteal = Random.Range(enemyScript.enemyHP -5f, enemyScript.enemyHP);
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
        playerScript.manaCounter += 4;
        turnCounter.turnCounter += 2;
    }
    private void FireBall()
    {
        float burn = Random.Range(10, 15);
        turnCounter.turnCounter += 2;
        enemyScript.enemyHP -= burn;
    }

    private void CrystalGolem()
    {
        float stun = 10f;
        turnCounter.turnCounter += 2;
        playerScript.manaCounter += 2;
        enemyScript.enemyHP -= stun;
    }

    private void DarkHole()
    {
        float holeDmg = 50f;
        enemyScript.enemyHP -= holeDmg;
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
            case "Fireball" : FireBall(); break;
            case "Spirit axe": SpiritAxe(); break;
            case "Crystal Golem": CrystalGolem(); break;
            case "Dark hole" : DarkHole(); break;
        }
    }
}