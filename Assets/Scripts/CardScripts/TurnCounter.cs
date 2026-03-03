using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TurnCounter : MonoBehaviour
{
    [SerializeField] Button NTButton;
    private int turnCounter = 0;
    private int manaCounter = 1;
    private int maxMana = 10;

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
        if(manaCounter <= maxMana && turnCounter % 2 == 0)
        {
            manaCounter++;
        }
        //Make a coroutine
        print(turnCounter);
    }

    
    //Pass turn by the button
     
    public void turnIncr()
    {
        turnCounter++;
    }


}
