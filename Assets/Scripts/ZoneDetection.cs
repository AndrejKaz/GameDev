using UnityEngine;
using UnityEngine.Rendering;

public class ZoneDetection : MonoBehaviour
{
    public EnemyDetection enemyDetection;
    public bool inZone = false;
    public bool enemyTeritory = false;

    void Start()
    {   
        //Get the game object bcs otherwise it will assign it null
        GameObject enemy = GameObject.FindWithTag("Enemy");
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
        if(!inZone && enemyTeritory)
        {
            print("Enemy speed is: " + enemyDetection.speed);
        }
    }

    void Update()
    {
        StartChase();
    }
}