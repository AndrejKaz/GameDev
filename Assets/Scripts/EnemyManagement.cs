using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    /*[===Game Objects===]*/
    public GameObject enemyPrefab;
    public GameObject enemyGround;

    /*[===References===]*/
    public EnemyGroundManagement enemyGroundManagement;

    /*[===Variables===]*/
    private List<GameObject> enemyList = new (); 
    private int enemyNum = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(enemyGround == null) print("No enemy ground found");
    }

    public void CreateEnemies(GameObject ground, int index)
    {
        Vector3 spawnPos = ground.transform.position + Vector3.up * 1f;
        for(int i = 0; i < enemyNum; i++)
        {
        
            //Create an enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            //Set the ground as the parent and make sure that the local scale is correct
            enemy.transform.SetParent(ground.transform, true);
            enemy.transform.localScale = new Vector3(0.033f, 1, 0.033f);

            //Set the data for the enemies            
            EnemyContainerData enemyData = enemy.GetComponent<EnemyContainerData>();

            if(enemyData != null) 
            {
                //Make sure you get the ground id for this
                SetEnemyData(enemyData, index);

                print("Enemy name: " + enemyData.enemyName);
                print("Enemy hp: " + enemyData.enemyHP);
                print("Enemy atk: " + enemyData.enemyATK);
                print("ENemy id: " + enemyData.enemyID);
            }

            //Add the new enemies in the list
            enemyList.Add(enemy);
        }
    }

    private void SetEnemyData(EnemyContainerData enemyData,int index)
    {
        switch (index % 4)
        {
            case 0:
                enemyData.enemyID = 0;
                enemyData.enemyName = "Slime";
                enemyData.enemyHP = 30f;
                enemyData.enemyATK = 5f;
            break;

            case 1:
                enemyData.enemyID = 1;
                enemyData.enemyName = "Skeleton";
                enemyData.enemyHP = 56f;
                enemyData.enemyATK = 12f;
            break;

            case 2:
                enemyData.enemyID = 2;
                enemyData.enemyName = "Fire Spirit";
                enemyData.enemyHP = 40f;
                enemyData.enemyATK = 17f;
            break;

            case 3:
                enemyData.enemyID = 3;
                enemyData.enemyName = "Golem";
                enemyData.enemyHP = 85f;
                enemyData.enemyATK = 30f;
            break;
        }
    }
}
