using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CardDrag : MonoBehaviour
{
    [SerializeField] GameObject Card;
    
    private UnityEngine.Vector3 startingPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Card == null) print("Card not found");
        
    }

    //Drag and drop cards
    public void OuseDown()
    {
        startingPos = Card.transform.position;    
    }

    void OnMouseDrag()
    {
        Card.transform.position = GetMousePosInWorld();
    }

    public void Op()
    {
        print("Card has been dropped");
        Card.transform.position = startingPos;
    }

    //Getting the current mouse pos in the world
    public UnityEngine.Vector3 GetMousePosInWorld()
    {
        UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }
}
