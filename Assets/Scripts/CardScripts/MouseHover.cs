using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MouseHover : MonoBehaviour
{
    [SerializeField] GameObject card;
    [SerializeField] float hoverMultiplier = 1.5f;
    [SerializeField] float animationSpeed = 10f;
    [SerializeField] AudioClip hoverClip;
    private AudioSource audioSource;
    [SerializeField] TextMeshPro TMP;
    private CardContainerData cardData;

    private Vector3 originalScale;
    private Vector3 targetScale;

    void Start()
    {
        cardData = card.GetComponent<CardContainerData>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        originalScale = card.transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        card.transform.localScale = Vector3.Lerp(card.transform.localScale,targetScale,Time.deltaTime * animationSpeed);
    }

    void OnMouseOver()
    {
        TMP.text = cardData.cardEffect;
        targetScale = originalScale * hoverMultiplier;
        audioSource.clip = hoverClip;
        audioSource.Play();
    }

    void OnMouseExit()
    {
        targetScale = originalScale;   
        TMP.text = "";
    }
}