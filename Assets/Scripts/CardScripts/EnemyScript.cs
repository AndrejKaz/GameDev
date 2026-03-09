using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    

    /*[===VARIABLES===]*/
    private float enemyATK = 10.0f;
    public bool hasAttacked = false;
    public float enemyHP = 10.0f;
    

    /*[===REFERENCES===]*/
    public TurnCounter turnCounter;
    public PlayerScript playerScript;
    private bool isAlive = true;

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

        EnemyLives();
        StartCoroutine(EnemyDies());
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

    public bool EnemyLives()
    {
        if(enemyHP <= 0.0f) isAlive = false;
        return isAlive;
    }

    public IEnumerator EnemyDies()
    {
        if(isAlive == false)
        {
            yield return new WaitForSeconds(1);
            Destroy(Enemy);

            /*[===PROBLEM HERE===]*/
            // yield return new WaitForSeconds(2);
            // SceneManager.LoadScene(0);
        }
    }
}
