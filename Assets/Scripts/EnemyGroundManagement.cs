using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundManagement : MonoBehaviour
{
    /*[===REFERENCES===]*/
    public GameObject enemyGroundPrefab;
    public EnemyManagement enemyManagement;


    /*[===VARIABLES===]*/
    private List<GameObject> enemyGroundList = new ();
    private int groundNum = 13;
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
                    spawnPos = new Vector3(-20f, -0.48f, 30f);
                    ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 1: 
                    spawnPos = new Vector3(20f, -0.48f, 45f);
                    ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 2: 
                    spawnPos = new Vector3(60f, -0.48f, 10f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 3: 
                    spawnPos = new Vector3(45f, -0.48f, 45f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 5: 
                    spawnPos = new Vector3(120f, -0.48f, 80f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 6: 
                    spawnPos = new Vector3(80f, -0.48f, -60f);
                    ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 7: 
                    spawnPos = new Vector3(-80f, -0.48f, -30f);
                     ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 8: 
                    spawnPos = new Vector3(-45f, -0.48f, 60f);
                    ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 9: 
                    spawnPos = new Vector3(100f, -0.48f, -20f);
                    ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 10: 
                    spawnPos = new Vector3(-60f, -0.48f, -80f);
                    ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 11: 
                    spawnPos = new Vector3(30f, -0.48f, -50f);
                    ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
                case 12: 
                    spawnPos = new Vector3(-100f, -0.48f, 20f);
                    ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
                    enemyGroundList.Add(ground);
                    enemyManagement.CreateEnemies(ground, groundId);
                break;
            }
         }
    }
}
