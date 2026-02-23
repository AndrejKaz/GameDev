using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class HandView : MonoBehaviour
{
    /*[===GAME-OBJECTS===]*/
    [SerializeField] SplineContainer hand;
    [SerializeField] GameObject deck;
    [SerializeField] GameObject cardPrefab;

    /*[===VARIABLES===]*/
    private int maxHandSize = 8;
    private List<GameObject> handCards = new();
    private float animationDuration = 0.25f;

    void Start()
    {
        //The deck is missing
        if (deck == null) return;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) DrawCard();
    }

    private void UpdateCardPosition()
    {
        if (handCards.Count == 0) return;

        float cardSpacing = 1.5f / maxHandSize;
        float firstCardPosition = 0.5f - (handCards.Count - 1) * cardSpacing / 2;
        Spline spline = hand.Spline;

        for (int i = 0; i < handCards.Count; i++)
        {
            float pos = firstCardPosition + i * cardSpacing;

            // Convert spline local position to world position
            Vector3 splinePosition = hand.transform.TransformPoint(spline.EvaluatePosition(pos));

            Vector3 up = hand.transform.TransformDirection(spline.EvaluateUpVector(pos));

            // Fix the -90 X rotation: use forward as the card's up axis
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, up);

            StartCoroutine(MoveCard(handCards[i], splinePosition, rotation));
        }
    }

    private IEnumerator MoveCard(GameObject card, Vector3 targetPosition, Quaternion targetRotation)
    {
        float elapsed = 0f;
        Vector3 startPosition = card.transform.position;
        Quaternion startRotation = card.transform.rotation;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);
            float smoothT = t * t * (3f - 2f * t);

            card.transform.position = Vector3.Lerp(startPosition, targetPosition, smoothT);
            card.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, smoothT);

            yield return null;
        }

        card.transform.position = targetPosition;
        card.transform.rotation = targetRotation;
    }

    private void DrawCard()
    {
        if (handCards.Count >= maxHandSize) return;
        GameObject card = Instantiate(cardPrefab, deck.transform.position, deck.transform.rotation);
        handCards.Add(card);
        UpdateCardPosition();
    }
}