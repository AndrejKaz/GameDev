using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{

    /*[===Game Objects===]*/
    public GameObject enemyPrefab;
    public GameObject enemyGround;

    /*[===Variables===]*/
    private List<GameObject> enemyList = new (); 
    private int enemyNum = 10;

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

            EnemyContainerData enemyData = enemy.GetComponent<EnemyContainerData>();

            if (enemyData != null)
                {
                    SetEnemyData(enemyData, enemyGroundManagement.groundId);
                    Debug.Log($"Enemy {i} set to: {enemyData.enemyName} | HP: {enemyData.enemyHP} | ATK: {enemyData.enemyATK}");
                }
                else
                {
                    Debug.LogWarning($"Enemy {i} is missing EnemyContainerData component!");
                }

            if(enemy != null) SetEnemyData(enemyData, enemyGroundManagement.groundId);

            enemyList.Add(enemy);
        }
    }

    private void SetEnemyData(EnemyContainerData data, int index)
    {
        switch (index)
        {
            case 0:
                data.enemyName = "Slime";
                data.enemyHP = 40f;
                data.enemyATK = 8f;
            break;
            case 1:
                data.enemyName = "Fire Spirit";
                data.enemyHP = 60f;
                data.enemyATK = 12f;
            break;
            case 2:
                data.enemyName = "Crystal Guardian";
                data.enemyHP = 100f;
                data.enemyATK = 20f;
            break; 
            case 3:
                data.enemyName = "Skeleton Warrior";
                data.enemyHP = 60f;
                data.enemyATK = 16f;
            break;

        }
    }
}
