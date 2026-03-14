using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCombat : MonoBehaviour
{
    public EnemyContainerData enemyContainerData;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("CombatScene");
        }
    }
}
