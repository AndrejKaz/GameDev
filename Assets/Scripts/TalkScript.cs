using TMPro;
using UnityEngine;

public class TalkScript : MonoBehaviour
{
    public TextMeshPro TMP;
    public PlayerBridgeData playerBridgeData;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerBridgeData.Coins >= 20)
            {
                TMP.text = "YOU GOT THE BEER BOTTOMS UP!";
            }
            else TMP.text = "YOU NEED 20 COINS TO BUY A BEER.";
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
