using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTavern : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Tavern");
        }
    }
}
