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
    public float enemyATK;
    public float enemyHP;
    public int enemyID;
    public string enemyName;
    public bool hasAttacked = false;
    private bool isAlive = true;
    private bool isDead = false;

    void Awake()
    {
        GameObject enemyBridgeData = GameObject.FindGameObjectWithTag("BridgeData");
        EnemyBridgeData bridgedData = enemyBridgeData.GetComponent<EnemyBridgeData>();

        //Get the data from the 3d scene
        enemyName = bridgedData.BridgeEnemyName;
        enemyHP = bridgedData.BridgeEnemyHP;
        enemyATK = bridgedData.BridgeEnemyATK;
        enemyID = bridgedData.BridgeEnemyID;

        print("My name is: " + enemyName);
        print("My HP is: " + enemyHP);
        print("My ATK is: " + enemyATK);
        print("My ID is: " + enemyID);
    }

    void Update()
    {
        if(turnCounter.turnCounter % 2 != 0 && hasAttacked == false)
        {
            hasAttacked = true;
            StartCoroutine(EnemyHit());
        }
        
        

        EnemyLives();
        
        if(isAlive == false && !isDead)
        {
            isDead = true;
            StartCoroutine(EnemyDies());
        }
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

    private IEnumerator EnemyDies()
    {
        Enemy.SetActive(false);
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(2);
    }
}
