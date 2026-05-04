using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;


public class EnemyScript : MonoBehaviour
{
    /*[===GameObjects===]*/
    [SerializeField] GameObject Enemy;    
    [SerializeField] private Sprite[] enemySprites;

    /*[===REFERENCES===]*/
    public TurnCounter turnCounter;
    public PlayerScript playerScript;
    public PlayerBridgeData playerBridgeData;

    /*[===VARIABLES===]*/
    public float enemyATK;
    public float enemyHP;
    public int enemyID;
    public string enemyName;
    public bool hasAttacked = false;
    public int uniqueID;
    private bool isAlive = true;
    private bool isDead = false;
    [SerializeField] ParticleSystem ps;
    private ParticleSystem.ColorOverLifetimeModule psModule;

    void Start()
    {
        GameObject enemyBridgeData = GameObject.FindGameObjectWithTag("BridgeData");
        EnemyBridgeData bridgedData = enemyBridgeData.GetComponent<EnemyBridgeData>();

        psModule = ps.colorOverLifetime;
        psModule.enabled = true;
        SetColor(uniqueID);

        enemyName = bridgedData.BridgeEnemyName;
        enemyHP = bridgedData.BridgeEnemyHP;
        enemyATK = bridgedData.BridgeEnemyATK;
        enemyID = bridgedData.BridgeEnemyID;
        uniqueID = bridgedData.BridgeUniqueID;

        if (enemySprites != null)
        {
            SpriteRenderer sr = Enemy.GetComponent<SpriteRenderer>();
            if (sr != null) sr.sprite = enemySprites[enemyID];
        }
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
        psModule.color = Color.red;

        yield return new WaitForSeconds(1);

        psModule.color = SetColor(uniqueID);

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
        GameObject enemyBridgeData = GameObject.FindGameObjectWithTag("BridgeData");
        EnemyBridgeData bridgedData = enemyBridgeData.GetComponent<EnemyBridgeData>();

        if(enemyHP <= 0.0f)
        {
            isAlive = false;
            bridgedData.enemyDead = true;
        }
        return isAlive;
    }

    private IEnumerator EnemyDies()
    {
        Enemy.SetActive(false);
        if (PlayerBridgeData.Instance != null) PlayerBridgeData.Instance.Coins++;
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(2);
    }

    private Color SetColor(int enemyId)
    {
        switch (enemyId)
        {
            case 0: return Color.green;
            case 1: return Color.cyan;
            case 2: return Color.black;
            case 3: return Color.gray;
            default: return Color.white;
        }
    }
}
