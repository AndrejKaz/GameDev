using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCombat : MonoBehaviour
{
    private Scene scene;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("CombatScene");
        }
    }
}
