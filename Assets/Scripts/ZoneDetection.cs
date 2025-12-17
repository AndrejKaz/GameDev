using UnityEngine;

public class DetectionWall : MonoBehaviour
{
    private Collider wallCollider;
    public bool inZone = false;

    void Awake()
    {
        wallCollider = GetComponent<Collider>();
        wallCollider.isTrigger = true;
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
            print("Player exited the zone" + inZone);
        }
    }
}
