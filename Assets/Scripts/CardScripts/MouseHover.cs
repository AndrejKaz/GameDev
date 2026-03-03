using UnityEngine;

public class MouseHover : MonoBehaviour
{
    [SerializeField] GameObject card;
    [SerializeField] float hoverMultiplier = 1.5f;
    [SerializeField] float animationSpeed = 10f;

    private Vector3 originalScale;
    private Vector3 targetScale;

    void Start()
    {
        originalScale = card.transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        card.transform.localScale = Vector3.Lerp(
            card.transform.localScale,
            targetScale,
            Time.deltaTime * animationSpeed
        );
    }

    void OnMouseOver()
    {
        targetScale = originalScale * hoverMultiplier;
    }

    void OnMouseExit()
    {
        targetScale = originalScale;
    }
}