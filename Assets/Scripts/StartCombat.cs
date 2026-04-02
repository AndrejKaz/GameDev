using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCombat : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        //Get the enemy game object
        GameObject enemy = this.gameObject;

        if (!other.gameObject.CompareTag("Player")) return;

        BridgeDataOnCollision(enemy);

        print(enemy);

        //SceneManager.LoadScene("CombatScene");
    }

    void Awake()
    {
        //Get the stored data
        GameObject enemyBridgeData = GameObject.FindGameObjectWithTag("BridgeData");
        EnemyBridgeData bridgeData = enemyBridgeData.GetComponent<EnemyBridgeData>();
        
        //Do not destroy the needed data
        DontDestroyOnLoad(enemyBridgeData);
        
        if (bridgeData.enemyDead == true)
        {
            Destroy(this.gameObject);

            //Erase the data bcs this was the huge problem
            bridgeData.BridgeEnemyATK = 0f;
            bridgeData.BridgeEnemyHP = 0f; 
            bridgeData.BridgeEnemyID = 0;
            bridgeData.BridgeEnemyName = "";
            bridgeData.BridgeUniqueID = 0;
            bridgeData.enemyDead = false;  
        }
    }
    private void BridgeDataOnCollision(GameObject enemy)
    {
        EnemyContainerData enemyData = enemy.GetComponent<EnemyContainerData>();
        
        //First finding the gameobj in the scene then getting the component so it wont be null
        GameObject enemyBridgeData = GameObject.FindGameObjectWithTag("BridgeData");
        EnemyBridgeData bridgedData = enemyBridgeData.GetComponent<EnemyBridgeData>();

        //Set the data so you can pass it in the 2d scene
        bridgedData.BridgeEnemyID = enemyData.enemyID;
        bridgedData.BridgeEnemyName = enemyData.enemyName;
        bridgedData.BridgeEnemyHP = enemyData.enemyHP;
        bridgedData.BridgeEnemyATK = enemyData.enemyATK;
        bridgedData.BridgeUniqueID = enemyData.uniqueID;
        bridgedData.enemyDead = false;
    }
}