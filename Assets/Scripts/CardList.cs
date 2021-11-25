using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardList : MonoBehaviour
{

    [SerializeField]
    Transform cardFieldTransform1,
            cardFieldTransform2,
            cardFieldTransform3,
            cardFieldTransform4,
            cardFieldTransform5,
            cardFieldTransform6,
            cardFieldTransform7,
            cardFieldTransform8;
    [SerializeField] Transform[] cardFieldTransform = new Transform[8];
    [SerializeField] Transform KeepCardPlayer1Transform;
    [SerializeField] Transform KeepCardPlayer2Transform;
    //public List<string> player1LetterList = new List<string>();
    [SerializeField] GameObject[] Cards = new GameObject[4];
    [SerializeField] CardController cardPrefab;
    //public string answerText;
    string answerTextStr;
    [SerializeField] TextInput textInputPlayer1;
    [SerializeField] TextInput textInputPlayer2;
    //public string ttext = textInput.GetComponent<Text>().text;
    [SerializeField] GameObject acceptButtonPrefab;
    [SerializeField] GameObject rejectButtonPrefab;
    [SerializeField] Text answerText;
    public GameObject canvas;
    public GameObject AcceptObjk, RejectObjk;
    public static int playerNum;
    JudgeButtunAction judgeButtunAction;
    string fieldNumber;

    int deckNumber = 0;
    CardController[] playerCardList;

    void Start()
    {
        Debug.Log(answerTextStr);
        StartGame();
    }

    void StartGame()
    {
        //Shuffle(Cards);
        /*
        SpawnCard(cardFieldTransform1);
        SpawnCard(cardFieldTransform2);
        SpawnCard(cardFieldTransform3);
        SpawnCard(cardFieldTransform4);
        SpawnCard(cardFieldTransform5);
        SpawnCard(cardFieldTransform6);
        SpawnCard(cardFieldTransform7);
        SpawnCard(cardFieldTransform8);
        */

        for (int i = 0; i < cardFieldTransform.Length; i++)
        {
            SpawnCard(cardFieldTransform[i]);
        }


    }
    void Update()
    {
        //Judgeボタン押した後の方がいいと思う
        //Debug.Log(JudgeButtunAction.selectJudge);
        if (JudgeButtunAction.selectJudge == true)
        {
            /*
            DealCard(cardFieldTransform1);
                        DealCard(cardFieldTransform2);
                        DealCard(cardFieldTransform3);
                        DealCard(cardFieldTransform4);
                        DealCard(cardFieldTransform5);
                        DealCard(cardFieldTransform6);
                        DealCard(cardFieldTransform7);
                        DealCard(cardFieldTransform8);
            */


            for (int i = 0; i < cardFieldTransform.Length; i++)
            {
                DealCard(cardFieldTransform[i]);
            }

            JudgeButtunAction.selectJudge = false;
            Debug.Log("playerNum" + playerNum);
            DestroyKeepCards(playerNum);
            answerText.text = "";
            switch (playerNum)
            {
                case 1:
                    textInputPlayer1.inputField.text = "";
                    break;
                case 2:
                    textInputPlayer2.inputField.text = "";
                    break;
                default:
                    break;
            }

            //InputTextとAnswerTextを空白に
        }
    }

    public void CheckLetter(int playerNumber) //playerNumber でどのプレイヤーのワードをチェックするか決める
    {
        answerTextStr = "empty";
        playerNum = playerNumber;
        bool checkContainsLetter = false; //入力文字列にカードの文字が含まれているかを判定
        Debug.Log("CheckLetter" + playerNum);
        switch (playerNumber)
        {
            case 1:
                Debug.Log("player1 check!");
                playerCardList = KeepCardPlayer1Transform.GetComponentsInChildren<CardController>();
                answerTextStr = textInputPlayer1.inputField.text;
                Debug.Log("Player1の入力内容answertext" + answerTextStr.ToString());
                Debug.Log("textInputPlayer1のtype：" + textInputPlayer1.text.GetType());
                Debug.Log("Player1の入力内容" + textInputPlayer1.text.ToString());
                break;
            case 2:
                Debug.Log("player2 check!");
                playerCardList = KeepCardPlayer2Transform.GetComponentsInChildren<CardController>();
                answerTextStr = textInputPlayer2.inputField.text;
                Debug.Log("Player2の入力内容" + answerTextStr);
                Debug.Log("textInputPlayer2のtype：" + textInputPlayer2.text.GetType());
                Debug.Log(textInputPlayer2.text.ToString());
                break;
            default:
                playerCardList = null;
                break;
        }
        //CardController[] playerCardList = KeepCardPlayer1Transform.GetComponentsInChildren<CardController>();
        //CardController[] player2CardList = KeepCardPlayer2Transform.GetComponentsInChildren<CardController>();
        Debug.Log("playerCardListの長さ：" + playerCardList.Length);
        //Debug.Log(playerCardList[1].model.letter);
        string[] player1LetterList = new string[playerCardList.Length];
        Debug.Log("ここまでできてる");
        //Debug.Log(answerText.GetType());
        // Debug.Log("textInputのtype：" + textInput.text.GetType());
        //Debug.Log(textInput.text.ToString());

        //answerText = ttext;
        //answerText = textInput.inputField.text;
        //Debug.Log(answerText);
        for (int i = 0; i < playerCardList.Length; i++) //Playerのキープ札の文字を配列に格納
        {
            Debug.Log(playerCardList[i].model.letter);
            player1LetterList[i] = playerCardList[i].model.letter;
            Debug.Log(string.Join(",", player1LetterList));
            if (!answerTextStr.Contains(player1LetterList[i])) //ここここここここ！！！
            {
                checkContainsLetter = CheckSpecialLetter(player1LetterList[i], answerTextStr);
            }
            else
            {
                checkContainsLetter = true;
            }
            Debug.Log("入力があっているか" + checkContainsLetter);
        }
        if (checkContainsLetter == true)
        {
            JudgeByOpponent(playerNumber);
            checkContainsLetter = false;
        }
        //answerTextStr = null;
    }

    public void DealCard(Transform cardFieldTransform) //場にカードがないエリアがある時、カードをSpawnさせる
    {
        int cardCount = cardFieldTransform.childCount;
        if (cardCount == 0)
        {
            SpawnCard(cardFieldTransform);
        }
    }
    public void SpawnCard(Transform spawnArea)　// カードを生成
    {
        CardController card = Instantiate(cardPrefab, spawnArea, false);
        card.Init(deckNumber);
        if (deckNumber < 44)
        {
            deckNumber++;
        }
        else
        {
            Scoreing();
        }

        /*
        for (int i = 0; i < 4; i++) // 3回繰り返す
        {
            
            if(i%5 == 0){
                Instantiate(Cards[i], new Vector3(100.0f, 100.0f, 0), Quaternion.identity); // カード生成
                Debug.Log("aaa" + Cards[i].transform.position.x);
            }else if(i%5 == 1){
                Instantiate(Cards[i], new Vector3(0, 0), Quaternion.identity); // カード生成
            }else if(i%5 == 2){
                Instantiate(Cards[i], new Vector3(20, 20), Quaternion.identity); // カード生成
            }else if(i%5 == 3){
                Instantiate(Cards[i], new Vector3(30, 30), Quaternion.identity); // カード生成
            }else if(i%5 == 4){
                Instantiate(Cards[i], new Vector3(50, 50), Quaternion.identity); // カード生成
            }
            
            
        }*/
    }

    void JudgeByOpponent(int playerNumber)
    {//判定ボタンの表示
        AcceptObjk = Instantiate(acceptButtonPrefab);
        AcceptObjk.transform.SetParent(canvas.transform, false);
        RejectObjk = Instantiate(rejectButtonPrefab);
        RejectObjk.transform.SetParent(canvas.transform, false);

        //キープカードをすべて消す


    }
    void DestroyKeepCards(int playerNumber)
    {
        int cardCount;
        switch (playerNumber)
        {

            case 1:
                cardCount = KeepCardPlayer1Transform.childCount;

                Debug.Log("Destroy");
                foreach (Transform keepCardChild in KeepCardPlayer1Transform)
                {
                    Destroy(keepCardChild.gameObject);
                }
                break;
            case 2:
                cardCount = KeepCardPlayer2Transform.childCount;

                foreach (Transform keepCardChild in KeepCardPlayer2Transform)
                {
                    Destroy(keepCardChild.gameObject);
                }
                break;
            default:
                Debug.Log("couldnt get playerNumber");
                break;

        }

    }
    void Scoreing()
    { //deckがすべてなくなったとき＜＜＜ここでシーン遷移する！
        this.GetComponent<ToResultScene>().SetScore();
        SceneManager.LoadScene("ResultScene");

    }
    /*
    public void OnClick(int number){
            switch (number)
            {
                case 0:
                    Debug.Log("Accept");
                    //獲得カードの表記変える

                    break;
                case 1:
                    Debug.Log("Reject");
                    //
                    break;
                default:
                    break;
            }

        }
    */

    bool CheckSpecialLetter(string letter, string answerTextStr)
    {
        bool checkEqal = false;
        string[] specialLetter = { "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "は", "ひ", "ふ", "へ", "ほ", "は", "ひ", "ふ", "へ", "ほ", "や", "ゆ", "よ", "つ", "あ", "い", "う", "え", "お" },
                toleranceLetter = { "が", "ぎ", "ぐ", "げ", "ご", "ざ", "じ", "ず", "ぜ", "ぞ", "だ", "ぢ", "づ", "で", "ど", "ば", "び", "ぶ", "べ", "ぼ", "ぱ", "ぴ", "ぷ", "ぺ", "ぽ", "ゃ", "ゅ", "ょ", "っ", "ぁ", "ぃ", "ぅ", "ぇ", "ぉ" };
        for (int i = 0; i < specialLetter.Length; i++)
        {
            if (letter == specialLetter[i] && answerTextStr.Contains(toleranceLetter[i]))
            {
                checkEqal = true;
            }
        }
        return checkEqal;
    }

}
