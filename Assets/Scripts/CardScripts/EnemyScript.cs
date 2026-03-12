using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;


public class EnemyScript : MonoBehaviour
{
    /*[===GameObjects===]*/
    [SerializeField] GameObject Enemy;
    
    /*[===REFERENCES===]*/
    public TurnCounter turnCounter;
    public PlayerScript playerScript;

    /*[===VARIABLES===]*/
    private float enemyATK;
    public bool hasAttacked = false;
    public float enemyHP = 10.0f;
    private bool isAlive = true;

    void Start()
    {        
        if(Enemy == null) print("Enemy not found");
    }

    void Update()
    {
        if(turnCounter.turnCounter % 2 != 0 && hasAttacked == false)
        {
            hasAttacked = true;
            StartCoroutine(EnemyHit());
        }
        
        print("Current enemy hp: " + enemyHP);

        EnemyLives();
        
        if(isAlive == false)
        {
            StartCoroutine(EnemyDies());
        }

        StartCoroutine(EnemyHeal());
    }

    public IEnumerator EnemyHit()
    {
        //Get a crit chance which is 1 in 5 and make a crit atk
        int rand = UnityEngine.Random.Range(0,6);
        float critAtk = enemyATK / 2;
        enemyATK = UnityEngine.Random.Range(5f, 10f);

        if(rand == 1)
        {
            playerScript.playerHP -= (enemyATK + critAtk);
        }

        playerScript.playerHP -= enemyATK;

        //Pass turn from enemy
        yield return new WaitForSeconds(1);
        turnCounter.turnIncr();
    }

    private IEnumerator EnemyHeal()
    {
        int rand = UnityEngine.Random.Range(1,7);

        float heal = UnityEngine.Random.Range(10f, 20f);
        
        //Heal enemy [TWEAK THIS LATER ON]
        if(rand == 1 && enemyHP <= 5f) enemyHP += heal;
    
        yield return new WaitForSeconds(1);
    }

    public float EnemyDefOnHit()
    {
        float enemyDEF = UnityEngine.Random.Range(0, 5);
        float DefenceEnemy = (enemyHP/100) * enemyDEF;
        return DefenceEnemy; 
    }

    public bool EnemyLives()
    {
        if(enemyHP <= 0.0f) isAlive = false;
        return isAlive;
    }

    public IEnumerator EnemyDies()
    {
        yield return new WaitForSeconds(1);
        Destroy(Enemy);

        /*[===PROBLEM HERE===]*/
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
        
    }
}
