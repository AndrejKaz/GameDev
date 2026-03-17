using UnityEngine;
using UnityEngine.Rendering;

public class ZoneDetection : MonoBehaviour
{
    /*[===References===]*/
    public EnemyDetection enemyDetection;
    public PlayerController playerController;

    /*[===Variables===]*/
    private Vector3 playerPos = new Vector3(0f,0f,0f);
    private GameObject enemy;
    private float enemyChaseSpeed = 0f;
    public bool inZone = false;
    public bool enemyTeritory = false;


    void Start()
    {   
        //Get the game object bcs otherwise it will assign it null
        enemy = GameObject.FindWithTag("Enemy");

        if(enemy != null) enemyDetection = enemy.GetComponent<EnemyDetection>();
        else Debug.LogWarning("Enemy not found!");
    }

    void FixedUpdate()
    {
        StartChase();    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            inZone = true;
            print("Player entered the zone" + inZone);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            inZone = false;
            enemyTeritory = true;
            print("Player exited the zone" + inZone);
        }
    }

    void StartChase()
    {
        //Get the current player position
        playerPos = playerController.rg.transform.position;     

        if(!inZone && enemyTeritory)
        {
            enemyChaseSpeed = (enemyDetection.speed + 2f)  * Time.deltaTime;

            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, playerPos, enemyChaseSpeed);
            if (Vector3.Distance(enemy.transform.position,  playerPos) < 0.01f)
            {
                //Reset position back
                enemy.transform.position *= -1.0f;
            }

            print("Enemy speed is: " + enemyDetection.speed);
        }
    }
}