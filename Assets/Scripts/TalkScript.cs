using TMPro;
using UnityEngine;

public class TalkScript : MonoBehaviour
{
    public TextMeshPro TMP;
    public PlayerBridgeData playerBridgeData;
    private int currCoins;

    void Start()
    {
        currCoins = playerBridgeData.Coins;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TMP.text = "You need 20 coins so you can buy a beer";
        }

        if (other.gameObject.CompareTag("Player") && currCoins >= 20)
        {
            TMP.text = "You got the beer bottoms up.";
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
                TMP.text = "";
            }    
    }

}
