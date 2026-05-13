using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class EnemyScript : MonoBehaviour
{
    /*[===GameObjects===]*/
    [SerializeField] GameObject Enemy;    
    [SerializeField] private Sprite[] enemySprites;

    /*[===REFERENCES===]*/
    public TurnCounter turnCounter;
    public PlayerScript playerScript;

    /*[===VARIABLES===]*/
    public float enemyATK;
    public float enemyHP;
    public int enemyID;
    public string enemyName;
    public bool hasAttacked = false;
    public int uniqueID;
    private bool isAlive = true;
    private bool isDead = false;
    [SerializeField] AudioClip hitClip;
    private AudioSource audioSource;
    public Slider slider;
    public Animator animator;

    void Start()
    {
        GameObject enemyBridgeData = GameObject.FindGameObjectWithTag("BridgeData");
        EnemyBridgeData bridgedData = enemyBridgeData.GetComponent<EnemyBridgeData>();

        enemyName = bridgedData.BridgeEnemyName;
        enemyHP = bridgedData.BridgeEnemyHP;
        enemyATK = bridgedData.BridgeEnemyATK;
        enemyID = bridgedData.BridgeEnemyID;
        uniqueID = bridgedData.BridgeUniqueID;
        slider.maxValue = enemyHP;

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
        
        audioSource = GetComponent<AudioSource>();

        playerScript.playerHP -= enemyATK;
        playerScript.slider.value = playerScript.playerHP;

        audioSource.clip = hitClip;
        audioSource.Play();

        //Pass turn from enemy
        animator.SetTrigger("enemyHit"); 
        
        yield return new WaitForSeconds(1);

        audioSource.Stop();

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

        int coinDrop = UnityEngine.Random.Range(1, 5);

        if (PlayerBridgeData.Instance != null) PlayerBridgeData.Instance.Coins += coinDrop;
        
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(2);
    }

}
