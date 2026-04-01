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

        SceneManager.LoadScene("CombatScene");
    }

    void Awake()
    {
        GameObject enemyBridgeData = GameObject.FindGameObjectWithTag("BridgeData");
        DontDestroyOnLoad(enemyBridgeData);
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

    }
}