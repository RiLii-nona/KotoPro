using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class JudgeButtunAction : MonoBehaviour
{
    Text scoreText;
    Transform KeepCardTransform;

    CardController[] playerCardList;
    [SerializeField] GameObject acceptButtonPrefab;
    [SerializeField] GameObject rejectButtonPrefab;
    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject cardPrefab;
    CardList cardList;
    public static bool selectJudge = false;
    public int i = 0;

    //public GameObject targetObj;


    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        cardList = GameManager.GetComponent<CardList>();
    }
    int playerNumByCardList;
    public void OnClick(int number)
    {
        cardList.blockRaycast.GetComponent<Image>().raycastTarget = false;
        //Debug.Log(KeepCardPlayer1Transform);

        //keepcardの子要素全て受け取ってtypeを確認

        /*
        if(playerNumber == null){
            return;
        }
        */
        //this.transform.DOScale(1.1f, 0.5f).SetEase(Ease.OutElastic);
        playerNumByCardList = CardList.playerNum;
        switch (number)
        {
            case 0:

                Debug.Log("Accept");
                //獲得カードの表記変える
                //forで子要素type見て加点していく

                //Debug.Log("pCLの長さ：" + playerCardList.Length);

                /*foreach (Transform keepCardChild in KeepCardPlayer1Transform)
                    {
                        Destroy(keepCardChild.gameObject);
                    }
                */
                ScoreAddition();
                Destroy(cardList.RejectObjk);
                StartCoroutine(DestroyAfterAnimation(cardList.AcceptObjk));
                //DestroyJudgeButton();
                selectJudge = true;
                //targetObj.GetComponent<CardList>().DealCard(cardFieldTransform1);
                //playerCardList = KeepCardPlayer2Transform.GetComponentsInChildren<CardController>();

                //scoreText.text = "aaa";
                break;
            case 1:

                Debug.Log("Reject");
                Destroy(cardList.AcceptObjk);
                StartCoroutine(DestroyAfterAnimation(cardList.RejectObjk));
                selectJudge = true;
                break;
            default:
                break;
        }
    }

    /*
    void ReturnCardsToField()
    {

        pastParent = cardPrefab.GetComponent<CardMovement>().pastParent;

        foreach (Transform keepCardCardChild in KeepCardTransform)
        {
            //Destroy(fieldCardChild.gameObject);
            transform.SetParent(pastParent[i].parent, false);
            i++;
        }

    }
    */
    void ScoreAddition()
    {
        int scoreInt;
        string playerNameStr;
        //Debug.Log(playerNum);
        switch (playerNumByCardList)
        {
            case 1:
                KeepCardTransform = GameObject.Find("KeepCardPlayer1").GetComponent<Transform>();
                playerNameStr = "Player1";
                Debug.Log(playerNameStr);
                break;

            case 2:
                KeepCardTransform = GameObject.Find("KeepCardPlayer2").GetComponent<Transform>();
                playerNameStr = "Player2";
                Debug.Log(playerNameStr);
                break;

            default:
                playerNameStr = "";
                break;
        }

        playerCardList = KeepCardTransform.GetComponentsInChildren<CardController>();
        for (int i = 0; i < playerCardList.Length; i++) //Player1のキープ札の文字を配列に格納
        {
            string playerNumStr = playerNameStr;
            Debug.Log("Cardの形" + playerCardList[i].model.type);
            if (playerCardList[i].model.type == 1)
            {

                playerNameStr += "Type1Score";
                Debug.Log(playerNameStr);
                scoreText = GameObject.Find(playerNameStr).GetComponent<Text>();
                Debug.Log("星だよーー");
            }
            else if (playerCardList[i].model.type == 2)
            {
                playerNameStr += "Type2Score";
                scoreText = GameObject.Find(playerNameStr).GetComponent<Text>();
                Debug.Log("丸だよーー");
            }
            else if (playerCardList[i].model.type == 3)
            {
                playerNameStr += "Type3Score";
                scoreText = GameObject.Find(playerNameStr).GetComponent<Text>();
                Debug.Log("六角形だよーー");
            }
            else if (playerCardList[i].model.type == 4)
            {
                playerNameStr += "Type4Score";
                scoreText = GameObject.Find(playerNameStr).GetComponent<Text>();
                Debug.Log("桜だよーー");
            }
            else
            {
                break;
            }
            scoreInt = Convert.ToInt32(scoreText.text.ToString());
            scoreInt++;
            scoreText.text = scoreInt.ToString();
            playerNameStr = playerNumStr;
        }


    }

    void DestroyJudgeButton()
    {
        GameManager = GameObject.Find("GameManager");
        cardList = GameManager.GetComponent<CardList>();
        Destroy(cardList.AcceptObjk);
        Destroy(cardList.RejectObjk);

    }


    /*
    public void GetPastParent(Transform defaultParent)
    {
        pastParent[i] = defaultParent;
        Debug.Log(pastParent[i]);
        i++;
    }
    */
    IEnumerator DestroyAfterAnimation(GameObject destroyObjk)
    {
        this.transform.DOScale(2.1f, 2.0f).SetEase(Ease.OutElastic);
        yield return new WaitForSeconds(0.3f);
        Destroy(destroyObjk);
    }
}

