using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundManagement : MonoBehaviour
{
    /*[===References===]*/
    public GameObject enemyGroundPrefab;
    public EnemyManagement enemyManagement;

    /*[===Variables===]*/
    private List<GameObject> enemyGroundList = new ();
    private int groundNum = 8;
    private bool hasCreated = false;
    public int groundId = 0;

    void Start()
    {   
        if(hasCreated) return;
        hasCreated = true;

        if(enemyGroundPrefab == null)
        {
            Debug.Log("No ground.");
            return;
        }
        CreateEnemyGround();
    }

    //Giving fixed positions to the ground spawner
    void CreateEnemyGround()
    {
        Vector3 spawnPos;
        GameObject ground;

        for (int i = 0; i < groundNum; i++)
        {
            groundId = i;


            switch (i)
            {
                case 0:
                    spawnPos = new Vector3(-20f, 0, 30f);
                    ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 1: 
                    spawnPos = new Vector3(20f, 0, 45f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 2: 
                    spawnPos = new Vector3(60f, 0, 10f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 3: 
                    spawnPos = new Vector3(45f, 0, 45f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 5: 
                    spawnPos = new Vector3(120f, 0, 80f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 6: 
                    spawnPos = new Vector3(80f, 0, -60f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 7: 
                    spawnPos = new Vector3(-80f, 0, -30f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
            }
         }
    }
}
