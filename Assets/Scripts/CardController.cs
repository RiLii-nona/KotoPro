using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    CardView view;
    public CardModel model;
    //public CardMovement movement;
    private void Awake()
    {
        view = GetComponent<CardView>();
    }
    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
        //このタイミングでspawnさせるのは画面外。DealAnimationで画面内にスライドさせるアニメーションを用いる。

    }

}
