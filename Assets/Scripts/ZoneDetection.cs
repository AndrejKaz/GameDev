using UnityEngine;
using UnityEngine.Rendering;

public class ZoneDetection : MonoBehaviour
{
    //Script references
    public EnemyDetection enemyDetection;
    public PlayerController playerController;

    //Player and enemy variables
    private Vector3 playerPos = new Vector3(0f,0f,0f);
    private GameObject enemy;
    private float enemyChaseSpeed = 0f;

    //Check if the player is in the zone
    public bool inZone = false;
    public bool enemyTeritory = false;

    void Start()
    {   
        //Get the game object bcs otherwise it will assign it null
        enemy = GameObject.FindWithTag("Enemy");

        if(enemy != null)
            enemyDetection = enemy.GetComponent<EnemyDetection>();
        else Debug.LogWarning("Enemy not found!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dude")) 
        {
            inZone = true;
            print("Player entered the zone" + inZone);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dude")) 
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
                // Reset the target position to the original object position.
                enemy.transform.position *= -1.0f;
            }

            print("Enemy speed is: " + enemyDetection.speed);
        }
    }

    void FixedUpdate()
    {
        StartChase();
    }
}