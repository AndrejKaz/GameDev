using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    //private float enemyHP = 100.0f;

    /*[===VARIABLES===]*/
    private float enemyATK = 10.0f;
    public bool hasAttacked = false;
    public float enemyHP = 100.0f;
    

    /*[===REFERENCES===]*/
    public TurnCounter turnCounter;
    public PlayerScript playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        if(Enemy == null) print("Enemy not found");
    }

    // Update is called once per frame
    void Update()
    {
        if(turnCounter.turnCounter % 2 != 0 && hasAttacked == false)
        {
            hasAttacked = true;
            StartCoroutine(EnemyHit());
        }

        print("Current player hp: " + playerScript.playerHP);
    }

    public IEnumerator EnemyHit()
    {
        int rand = UnityEngine.Random.Range(0,5);
        float critAtk = enemyATK / 2;

        if(rand == 1)
        {
            playerScript.playerHP -= (enemyATK + critAtk);
        }

        playerScript.playerHP -= enemyATK;
        yield return new WaitForSeconds(1);
        turnCounter.turnIncr();
    }
}
