using UnityEngine;
using System.Collections;

public class valasztas : MonoBehaviour
{
    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private bool isSelected = false;
    private static bool isWaiting = false;

    public float rotationAngle = 180f;
    public float rotationSpeed = 90f;
    public float smoothness = 2f;

    private void Start()
    {
        originalRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.left * rotationAngle + Vector3.up * rotationAngle);
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
        yield return new WaitForSeconds(2f);
        isWaiting = false;
        valasztas[] cards = FindObjectsOfType<valasztas>();
        foreach (valasztas card in cards)
        {
            card.UnselectCard();
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
}
