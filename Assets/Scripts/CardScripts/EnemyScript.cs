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
    public float enemyHP = 100.0f;
    private bool isAlive = true;
    private bool isDead = false;
    private int randHeal;

    void Start()
    {        
        if(Enemy == null) print("Enemy not found");
    }

    void Update()
    {
        randHeal = UnityEngine.Random.Range(0,6);

        if(turnCounter.turnCounter % 2 != 0 && hasAttacked == false)
        {
            hasAttacked = true;
            StartCoroutine(EnemyHit());
        }
        
        print("Current enemy hp: " + enemyHP);

        EnemyLives();
        
        if(isAlive == false && !isDead)
        {
            isDead = true;
            StartCoroutine(EnemyDies());
        }

        //StartCoroutine(EnemyHeal());
    }

    private IEnumerator EnemyHit()
    {
        //Get a crit chance which is 1 in 5 and make a crit atk
        int rand = UnityEngine.Random.Range(0,6);
        float critAtk = enemyATK / 2;
        enemyATK = UnityEngine.Random.Range(5f, 10f);

        if(rand == 1) playerScript.playerHP -= (enemyATK + critAtk);
    

        playerScript.playerHP -= enemyATK;

        //Pass turn from enemy
        yield return new WaitForSeconds(1);
        turnCounter.turnIncr();
    }

    private IEnumerator EnemyHeal()
    {
        float heal = UnityEngine.Random.Range(10f, 20f);
        
        if(randHeal == 1 && enemyHP <= 25f) enemyHP += heal;
    
        yield return new WaitForSeconds(1);
    }

    public float EnemyDefOnHit()
    {
        float enemyDEF = UnityEngine.Random.Range(0, 5);
        float DefenceEnemy = (enemyHP/100) * enemyDEF;
        return DefenceEnemy; 
    }

    private bool EnemyLives()
    {
        if(enemyHP <= 0.0f) isAlive = false;
        return isAlive;
    }

    /*The problem with the yield return new usage,
    make sure that you proprely incorparate it bcs it fucks it up for some reason
    */
    private IEnumerator EnemyDies()
    {
        Enemy.SetActive(false);
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(2);
    }
}
