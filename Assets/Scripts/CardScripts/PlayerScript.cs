using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Slider slider;
    public float playerHP = 100.0f;
    public int manaCounter = 1;
    public int maxMana = 20;

    void Start()
    {   
        slider.value = playerHP;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if(playerHP < 0)
        {
            SceneManager.LoadScene("IslandScene");
        }
    }
}
