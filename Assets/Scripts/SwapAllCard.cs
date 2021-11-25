using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapAllCard : MonoBehaviour
{
    [SerializeField] Transform[] cardFieldTransform;
    [SerializeField] GameObject tardetgameObject;
    CardList cardList;
    CardModel cardModel;
    int cardCount;
    bool existCard = true;
    bool reachLastCard = false;
    void Start()
    {

    }
    public void OnClick()
    {
        cardList = tardetgameObject.GetComponent<CardList>();
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

            if (existCard && cardList.deckNumber <= 43)
            {
                cardList.SpawnCard(cardFieldTransform[i]);
                //cardList.deckNumber = +8;
            }
            else if (existCard && cardList.deckNumber == 44)
            {
                reachLastCard = true;

            }
            else if (reachLastCard)
            {
                cardList.Scoreing();
            }
            existCard = true;
        }

    }
}
