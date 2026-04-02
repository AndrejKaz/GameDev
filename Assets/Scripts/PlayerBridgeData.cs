// On PlayerBridgeData.cs
using UnityEngine;

public class PlayerBridgeData : MonoBehaviour
{
    public static PlayerBridgeData Instance;

    public Vector3 currPos;
    public Vector3 lastPos;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}