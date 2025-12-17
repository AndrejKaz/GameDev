using UnityEngine;
using UnityEngine.AI;

public class EnemyDetection : MonoBehaviour
{
    /*[===Enemy movement===]*/
    public Rigidbody rg;
    public float speed = 5.0f;
    private GameObject[] targetPoints;
    private int index = 0;

    /*[===Scrpit references===]*/
    


    void Start()
    {
        rg.freezeRotation = true;
        targetPoints = GameObject.FindGameObjectsWithTag("TargetPoint");
    
    }
    
    void FixedUpdate()
    {
        if(index != 6) Move();
        else index = 0;
    }

    void Move()
    {
        Vector3 targetPos = targetPoints[index].transform.position;
        Vector3 direction = targetPos - transform.position;

        rg.MovePosition(transform.position + direction.normalized * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TargetPoint")) index++;
    }

}
