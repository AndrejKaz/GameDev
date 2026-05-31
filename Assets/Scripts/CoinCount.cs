using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
   
    void Awake()
    {
        textMeshProUGUI.text += PlayerBridgeData.Instance.Coins;
    }
}
