using System.Collections;
using TMPro;
using UnityEngine;

public class TalkScript : MonoBehaviour
{
    public TextMeshPro TMP;
    [SerializeField] TextMeshProUGUI coinTxt;
    [SerializeField] TextMeshProUGUI beerTxt;

    GameObject beer;
    private bool isBought = false;
    public int beerCount = 0;

    void Awake()
    {
        beer = GameObject.Find("Beer");
        beer.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerBridgeData.Instance.Coins >= 20)
            {
                isBought = true;
                TMP.text = "YOU GOT THE BEER BOTTOMS UP!";
                beer.SetActive(true);
                StartCoroutine(moreBeer());
                coinTxt.text = "";
                PlayerBridgeData.Instance.Coins -= 20;
                coinTxt.text += PlayerBridgeData.Instance.Coins;
                PlayerBridgeData.Instance.beerCount++;
                PlayerBridgeData.Instance.dmgBoost = PlayerBridgeData.Instance.beerCount;
                beerTxt.text = "";
                beerTxt.text += PlayerBridgeData.Instance.beerCount;
            }
            else
            {
                TMP.text = "YOU NEED 20 COINS TO BUY A BEER.";
            } 
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TMP.text = "";
            beer.SetActive(false);
        }    
    }

    private IEnumerator moreBeer()
    {
        if (isBought)
        {
            TMP.text = "READY FOR ANOTHER ROUND?";
            yield return new WaitForSeconds(1);
            isBought = false;
        }
    }

}
