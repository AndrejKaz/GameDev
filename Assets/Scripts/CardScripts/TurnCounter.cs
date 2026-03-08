using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TurnCounter : MonoBehaviour
{
    [SerializeField] Button NTButton;
    public int turnCounter = 0;

    //Ref
    public PlayerScript playerScript;
    public EnemyScript enemyScript;
    public HandView handView;

    private Button bt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bt = NTButton.GetComponent<Button>();
        bt.onClick.AddListener(turnIncr);
    }

    // Update is called once per frame
    void Update()
    {   
        print("Turn counter from turn counter script" + turnCounter);
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
}
