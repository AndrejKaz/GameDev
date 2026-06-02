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

        handView.RemoveCard(CardDrag.draggedCard.gameObject);
        Destroy(CardDrag.draggedCard.gameObject);

        playerScript.manaCounter -= cardData.manaCost;

        float damage = cardData.cardDmg / 10f + enemyScript.enemyID;
        enemyScript.enemyHP -= damage;
        enemyScript.slider.value = enemyScript.enemyHP;

        audioSource.clip = dropClip;
        audioSource.Play();

        CardEffect(cardData.cardName);

        print(damage);
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
        int rand = Random.Range(0, 2);
        if(rand == 1)
        {
        int randomMana = Random.Range(3, 7);
        playerScript.manaCounter += randomMana;
            
        }
    }
    private void SpiritArrow()
    {
        int rand = Random.Range(0, 2);
        float critDmg = Random.Range(5f, 7f);
        if (rand == 1) enemyScript.enemyHP -= critDmg;
        playerScript.manaCounter += 5;
    }
    private void EyeOfTheBeholder()
    {
        float lifeSteal = Random.Range(enemyScript.enemyHP -5f, enemyScript.enemyHP);
        playerScript.playerHP += lifeSteal;
    }
    private void FairyPotion()
    {   
        handView.DrawCard();
        playerScript.manaCounter += 6;
    }
    private void FairyWand()
    {
        handView.DrawCard();
        playerScript.manaCounter += 4;
    }
    private void FireBall()
    {
        float burn = Random.Range(10, 15);
        enemyScript.enemyHP -= burn;
    }

    private void CrystalGolem()
    {
        playerScript.manaCounter += 3;
        float stun = Random.Range(15, 18);
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
            case "Crystal golem": CrystalGolem(); break;
            case "Dark hole" : DarkHole(); break;
        }
    }
}