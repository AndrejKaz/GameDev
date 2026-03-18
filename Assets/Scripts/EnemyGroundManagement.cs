using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundManagement : MonoBehaviour
{
    /*[===References===]*/
    public GameObject enemyGroundPrefab;
    public EnemyManagement enemyManagement;

    /*[===Variables===]*/
    private List<GameObject> enemyGroundList = new ();
    private int groundNum = 4;
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


     void CreateEnemyGround()
    {
        for (int i = 0; i < groundNum; i++)
        {
            groundId = i;
            Vector3 spawnPos = new Vector3(10f * (i + 2), 0, 10f * (i + 2));
            GameObject ground = Instantiate(enemyGroundPrefab, spawnPos, Quaternion.identity);
            enemyGroundList.Add(ground);

            enemyManagement.CreateEnemies(ground, groundId);

        }
    }
}
