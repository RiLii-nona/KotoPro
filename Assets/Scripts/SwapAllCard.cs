using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAllCard : MonoBehaviour
{
    [SerializeField] Transform[] cardFieldTransform;
    [SerializeField] GameObject tardetgameObject;
    int cardCount;
    bool existCard = true;
    public void OnClick()
    {
        Debug.Log("SwapAllCard!!!");
        for (int i = 0; i < cardFieldTransform.Length; i++)
        {
            cardCount = cardFieldTransform[i].childCount;
            if (cardCount == 0)
            {
                existCard = false;
            }
            foreach (Transform fieldCardChild in cardFieldTransform[i])
            {
                Destroy(fieldCardChild.gameObject);
            }
            if (existCard)
            {
                tardetgameObject.GetComponent<CardList>().SpawnCard(cardFieldTransform[i]);
            }
            existCard = true;
        }

    }
}
