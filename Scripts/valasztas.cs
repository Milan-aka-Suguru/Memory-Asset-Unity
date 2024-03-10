using UnityEngine;
using System.Collections;
using TMPro;
using System;
public class valasztas : MonoBehaviour
{
    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private bool isSelected = false;
    public bool isWaiting = false;
    public float rotationAngle = 180f;
    public float rotationSpeed = 90f;
    public float smoothness = 2f;
    private valasztas firstSelectedCard = null;

    private void Start()
    {        
        originalRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.left * rotationAngle + Vector3.up * rotationAngle);        
    }
    public void pontvalt(int p = 0){        
        GameObject.Find("Pontok").GetComponent<TMPro.TextMeshProUGUI>().text = p+"";
    }
    private void OnMouseDown()
    {
        if (!isWaiting)
        {
            if (isSelected)
            {
                UnselectCard();
            }
            else
            {
                int selectedCardCount = CountSelectedCards();
                if (selectedCardCount < 2)
                {
                    SelectCard();
                    if (selectedCardCount == 1)
                    {
                        firstSelectedCard = this;
                        StartCoroutine(WaitAndUnselect());
                    }
                }
            }
        }
    }

private void SelectCard()
    {
        // Smoothly rotate the card
        StartCoroutine(RotateCard(targetRotation));
        isSelected = true;
    }

    private void UnselectCard()
    {
        // Smoothly rotate the card back to its original rotation
        StartCoroutine(RotateCard(originalRotation));
        isSelected = false;
    }
    private int CountSelectedCards()
    {
        int count = 0;
        valasztas[] cards = FindObjectsOfType<valasztas>();
        foreach (valasztas card in cards)
        {
            if (card.isSelected)
            {
                count++;
            }
        }
        return count;
    }

    private IEnumerator WaitAndUnselect()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1f);
        isWaiting = false;

        valasztas[] cards = FindObjectsOfType<valasztas>();
        foreach (valasztas card in cards)
        {
            if (card.isSelected && card != firstSelectedCard)
            {
                if (HaveSameParent(firstSelectedCard.transform, card.transform))
                {
                    Destroy(firstSelectedCard.gameObject);
                    Destroy(card.gameObject);
                    this.pontvalt(int.Parse(GameObject.Find("Pontok").GetComponent<TMPro.TextMeshProUGUI>().text)+1);
                }
                else
                {
                    card.UnselectCard();
                    firstSelectedCard.UnselectCard();
                }
            }
        }
    }
private IEnumerator RotateCard(Quaternion targetRotation)
    {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        while (elapsedTime < 1f)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * smoothness;
            yield return null;
        }

        // Ensure final rotation is exact
        transform.rotation = targetRotation;
    }
    private bool HaveSameParent(Transform obj1, Transform obj2)
    {
        return obj1.parent == obj2.parent;
    }
}
