using UnityEngine;

public class DoorExit : MonoBehaviour
{
    private bool ifTalked = false;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(ifTalked == false)
            {
                print("XD NO TALK BRO");
            }
            else
            {
                print("Yes talk bro");
            }
        }
    }


}
