using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TurnCounter : MonoBehaviour
{
    [SerializeField] Button NTButton;
    [SerializeField] TextMeshPro text;
    public int turnCounter = 0;


    /*[===References===]*/
    public PlayerScript playerScript;
    public EnemyScript enemyScript;
    public HandView handView;
    
    /*[===Variables===]*/
    private Button bt;

    void Start()
    {
        bt = NTButton.GetComponent<Button>();
        bt.onClick.AddListener(turnIncr);
    }

    void Update()
    {   
        print("Turn counter from turn counter script" + turnCounter);
        UpdateManaCount();
    }
    
    //Pass turn by the button
    public void turnIncr()
    {
        turnCounter++;
        if (turnCounter % 2 == 0 && playerScript.manaCounter < playerScript.maxMana){
            playerScript.manaCounter++;
            handView.DrawCard();
            enemyScript.hasAttacked = false;
        }  
    }

    public void UpdateManaCount()
    {
        text.text = playerScript.manaCounter.ToString();
    }
}
