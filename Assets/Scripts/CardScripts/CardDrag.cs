using System.Numerics;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class CardDrag : MonoBehaviour
{
    [SerializeField] GameObject Card;

    public CardDropArea cardDropArea;
    public static CardDrag draggedCard;
    public PointerEventData whatData;
    private Vector3 startingPos;

    void Start()
    {
        if (Card == null) print("Card not found");
    }

    void OnMouseDown()
    {
        startingPos = Card.transform.position;
        draggedCard = this;
    }

    void OnMouseDrag()
    {
        Card.transform.position = GetMousePosInWorld();
    }

    void OnMouseUp()
    {  
        UnityEngine.Vector2 mousePos = GetMousePosInWorld();
        Collider2D hitCol = Physics2D.OverlapPoint(mousePos);

        if(hitCol != null)
        {
            //CARD DROP AREA
            cardDropArea.CardDrop();
        }
        {
            Card.transform.position = startingPos;
        }
    }

    public Vector3 GetMousePosInWorld()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }  
}