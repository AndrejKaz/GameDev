using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{

    /*[===Game Objects===]*/
    public GameObject enemyPrefab;
    public GameObject enemyGround;

    /*[===Variables===]*/
    private List<GameObject> enemyList = new (); 
    private int enemyNum = 2;

    /*[===References]*/
    public EnemyGroundManagement enemyGroundManagement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(enemyGround == null) print("No enemy ground found");

        CreateEnemies();
    }

    private void CreateEnemies()
    {

        for(int i = 0; i < enemyNum; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemyPrefab.transform.position, Quaternion.identity);
            enemy.transform.SetParent(enemyGround.transform, true);

            enemyList.Add(enemy);
        }
    }

}
