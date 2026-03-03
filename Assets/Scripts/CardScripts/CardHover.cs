using UnityEngine;
using UnityEngine.XR;

public class CardHover : MonoBehaviour
{
    [SerializeField] GameObject handView;
    public DeckManager deckManager;
    private GameObject myCard;

    void Start()
    {
        myCard = deckManager.cardPrefab;
    }

    public void Hover()
    {
        myCard.transform.position = new Vector3(0f,0f,0f);
    }

    public void OutHover()
    {
        myCard.transform.position = new Vector3(-2f,-1f,-2f);
    }


}
