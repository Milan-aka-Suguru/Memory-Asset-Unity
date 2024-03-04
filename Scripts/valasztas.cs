using UnityEngine;
using System.Collections;

public class valasztas : MonoBehaviour
{
    private Color originalColor;
    private Color highlightColor = Color.yellow;
    private bool isSelected = false;
    private static bool isWaiting = false;

    private void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
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
        GetComponent<Renderer>().material.color = highlightColor;
        isSelected = true;
    }

    private void UnselectCard()
    {
        GetComponent<Renderer>().material.color = originalColor;
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
}