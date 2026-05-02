using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    /*[===GAME OBJECTS===]*/
    public GameObject[] enemyPrefab;
    public GameObject enemyGround;

    /*[===REFERENCES===]*/
    public PlayerController playerController;

    /*[===VARIABLES===]*/
    private List<GameObject> enemyList = new();
    private int enemyNum = 1;

    void Awake()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Start()
    {
        if (enemyGround == null) print("No enemy ground found");
    }


    public void CreateEnemies(GameObject ground, int index)
{
    Vector3 spawnPos = ground.transform.position + Vector3.up * 1f;

    for (int i = 0; i < enemyNum; i++)
    {
        int typeIndex = (index + i) % enemyPrefab.Length; 

        GameObject enemy = Instantiate(enemyPrefab[typeIndex], spawnPos, Quaternion.identity);

        enemy.transform.SetParent(ground.transform, true);
        enemy.transform.localScale = new Vector3(0.033f, 1, 0.033f);

        EnemyContainerData enemyData = enemy.GetComponent<EnemyContainerData>();
        if (enemyData != null)
        {
            SetEnemyData(enemyData, index + i);
        }

        enemyList.Add(enemy);
    }
}

    private void SetEnemyData(EnemyContainerData enemyData, int index)
    {
        switch (index % 4)
        {
            case 0:
                enemyData.enemyID = 0;
                enemyData.enemyName = "Slime";
                enemyData.enemyHP = 30f;
                enemyData.enemyATK = 5f;
                enemyData.uniqueID = index;
                break;

            case 1:
                enemyData.enemyID = 1;
                enemyData.enemyName = "Skeleton";
                enemyData.enemyHP = 50f;
                enemyData.enemyATK = 12f;
                enemyData.uniqueID = index;
                break;

            case 2:
                enemyData.enemyID = 2;
                enemyData.enemyName = "Fire Spirit";
                enemyData.enemyHP = 40f;
                enemyData.enemyATK = 17f;
                enemyData.uniqueID = index;
                break;

            case 3:
                enemyData.enemyID = 3;
                enemyData.enemyName = "Golem";
                enemyData.enemyHP = 85f;
                enemyData.enemyATK = 30f;
                enemyData.uniqueID = index;
                break;
        }
    }

}