using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class SwapAllCard : MonoBehaviour
{
    [SerializeField] Transform[] cardFieldTransform;
    [SerializeField] GameObject tardetgameObject;
    [SerializeField] AnimationCurve animationCurve;
    CardList cardList;
    CardModel cardModel;
    int cardCount;
    bool existCard = true;
    bool reachLastCard = false;

    public void OnClick()
    {
        StartCoroutine("SwapAfterAnimation");

    }

    IEnumerator SwapAfterAnimation()
    {
        //this.transform.DOScale(1.0f, 1.0f).SetEase(Ease.OutElastic);
        DOTween.To(
  () => 0, //値(time)の初期値
  (time) => this.transform.localScale = Vector3.one * animationCurve.Evaluate(time),//値を使った処理
  1.0f, //値(time)の最終値
  0.5f //Tweenの時間
);
        yield return new WaitForSeconds(0.3f);
        SwapCards();
    }

    void SwapCards()
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
