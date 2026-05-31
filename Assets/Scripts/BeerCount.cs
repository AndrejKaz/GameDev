using TMPro;
using UnityEngine;

public class BeerCount : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI beerCount;

    void Awake()
    {
        beerCount.text += PlayerBridgeData.Instance.beerCount;
    }
}
