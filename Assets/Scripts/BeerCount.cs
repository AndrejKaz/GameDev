using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeerCount : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI beerCount;

    void Awake()
    {
        beerCount.text += PlayerBridgeData.Instance.beerCount;

        if(PlayerBridgeData.Instance.beerCount == 3)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
