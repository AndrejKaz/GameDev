using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float playerHP = 100.0f;
    public int manaCounter = 1;
    public int maxMana = 20;
    
    public int currCoins = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
