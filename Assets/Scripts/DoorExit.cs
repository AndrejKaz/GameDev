using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("IslandScene");
        }
    }
}
