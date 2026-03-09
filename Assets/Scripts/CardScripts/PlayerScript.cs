using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject Player;

    public float playerHP = 100.0f;
    public int manaCounter = 1;
    public int maxMana = 10;

    void Update()
    {
        print("Player mana: " + manaCounter);
    }
}
