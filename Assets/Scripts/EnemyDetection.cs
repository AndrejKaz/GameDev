using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    /*[===REFERENCES===]*/
    private Rigidbody rg;

    /*[===VARIABLES===]*/
    private GameObject[] targetPoints;
    private int index = 0;
    public float speed = 5.0f;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.freezeRotation = true;

        Transform waypointContainer = transform.parent.Find("TargetPoint-Group");
        if (waypointContainer == null) return;

        targetPoints = new GameObject[waypointContainer.childCount];
        for (int i = 0; i < waypointContainer.childCount; i++)
        {
            targetPoints[i] = waypointContainer.GetChild(i).gameObject;
        }
    }

    void FixedUpdate()
    {
        if (targetPoints == null || targetPoints.Length == 0) return;

        if (index != targetPoints.Length) Move();
        else index = 0;
    }

    private void Move()
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