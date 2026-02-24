using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class HandView : MonoBehaviour
{
    /*[===REFERENCES===]*/
    [SerializeField] private SplineContainer hand;
    [SerializeField] private DeckManager deckManager;

    /*[===VARIABLES===]*/
    [SerializeField] private int maxHandSize = 9;
    [SerializeField] private float animationDuration = 0.25f;

    /*[===GAMEOBJECTS===]*/
    private List<GameObject> handCards = new List<GameObject>();


    //DEBUG TIME
    private void Start()
    {
        if(deckManager.deckList == null) return;
        StartingHand();
    }
  



    private void StartingHand()
    {
        int cardsToDraw = 6;

        for (int i = 0; i < cardsToDraw; i++)
        {
            // Always take the top card (index 0)
            GameObject card = deckManager.deckList[0];
            handCards.Add(card);
            deckManager.deckList.RemoveAt(0);

            // Reparent to hand (so they move with the hand if needed)
            card.transform.SetParent(hand.transform, true);
        }

        // Position them along the spline
        UpdateCardPosition();
    }

    // (Rest of your methods: UpdateCardPosition, MoveCard, DrawCard – unchanged)
    private void UpdateCardPosition()
    {
        if (handCards.Count == 0) return;

        float cardSpacing = 1.5f / maxHandSize;
        float firstCardPosition = 0.5f - (handCards.Count - 1) * cardSpacing / 2;
        Spline spline = hand.Spline;

        for (int i = 0; i < handCards.Count; i++)
        {
            float t = firstCardPosition + i * cardSpacing;
            Vector3 targetPos = hand.transform.TransformPoint(spline.EvaluatePosition(t));
            Vector3 up = hand.transform.TransformDirection(spline.EvaluateUpVector(t));
            Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, up);

            StartCoroutine(MoveCard(handCards[i], targetPos, targetRot));
        }
    }

    private IEnumerator MoveCard(GameObject card, Vector3 targetPos, Quaternion targetRot)
    {
        float elapsed = 0f;
        Vector3 startPos = card.transform.position;
        Quaternion startRot = card.transform.rotation;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);
            float smoothT = t * t * (3f - 2f * t);
            card.transform.position = Vector3.Lerp(startPos, targetPos, smoothT);
            card.transform.rotation = Quaternion.Slerp(startRot, targetRot, smoothT);
            yield return null;
        }

        card.transform.position = targetPos;
        card.transform.rotation = targetRot;
    }
}