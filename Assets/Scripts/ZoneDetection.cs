using System.Runtime.CompilerServices;
using UnityEngine;

public class ZoneDetection : MonoBehaviour
{
    /*[===REFECERENES===]*/
    public EnemyDetection enemyDetection;
    private EnemyManagement enemyManagement;
        
    /*[===VARIABLES===]*/
    public PlayerController playerController;
    private GameObject enemy;
    private Vector3 playerPos = new Vector3(0f, 0f, 0f);
    private float enemyChaseSpeed = 0f;
    public bool enemyTeritory = false;

    void Start()
{
    GameObject wallGroup = this.gameObject;

    // Search siblings (children of the same ground transform)
    Transform ground = wallGroup.transform.parent;
    foreach (Transform child in ground)
    {
        if (child.CompareTag("Enemy"))
        {
            enemy = child.gameObject;
            break;
        }
    }

    if (enemy == null) Debug.LogWarning("No enemy found under ground: " + ground.name);

    enemyManagement = ground.GetComponent<EnemyManagement>();
    if (enemyManagement != null) playerController = enemyManagement.playerController;
}

    void FixedUpdate()
    {
        StartChase();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyTeritory = true;
            print("Player entered the zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyTeritory = false;
            print("Player left");
        }
    }

    //Start the enemy chase
    public void StartChase()
    {
        if (enemy == null) return;

        playerPos = playerController.rg.transform.position;

        if (enemyTeritory)
        {
            enemyChaseSpeed = (enemyDetection.speed + 2f) * Time.deltaTime;

            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, playerPos, enemyChaseSpeed);

            if (Vector3.Distance(enemy.transform.position, playerPos) < 0.01f)
            {
                enemyTeritory = false;
            }
        }
    }
}