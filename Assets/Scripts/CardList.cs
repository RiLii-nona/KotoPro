using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

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
            cardFieldTransform8,
            SpawnFieldTransform;
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
    [SerializeField] AudioClip cardSpawnSound;
    public GameObject canvas;
    public GameObject AcceptObjk, RejectObjk;
    public GameObject blockRaycast;
    public static int playerNum;
    JudgeButtunAction judgeButtunAction;
    string fieldNumber;

    public int deckNumber = 0;
    public CardController[] playerCardList;

    void Start()
    {
        blockRaycast.GetComponent<Image>().raycastTarget = false;
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

        /*
        for (int i = 0; i < cardFieldTransform.Length;)
        {
            SpawnCard(cardFieldTransform[i]);
            Debug.Log(i);
            //StartCoroutine(Interval(i));

        }
        */
        StartCoroutine("SpawnAllCards");

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
                Debug.Log("playerCardList.Length" + playerCardList.Length);
                Debug.Log("Player1の入力内容" + textInputPlayer1.text.ToString());
                break;
            case 2:
                Debug.Log("player2 check!");
                playerCardList = KeepCardPlayer2Transform.GetComponentsInChildren<CardController>();
                Debug.Log(textInputPlayer2.text.ToString());
                break;
            default:
                playerCardList = null;
                break;
        }
        if (playerCardList.Length >= 3)
        {
            switch (playerNumber)
            {
                case 1:
                    answerText.text = textInputPlayer1.inputField.text;
                    answerTextStr = textInputPlayer1.inputField.text;
                    Debug.Log("Player1の入力内容answertext" + answerTextStr.ToString());

                    break;
                case 2:
                    answerText.text = textInputPlayer2.inputField.text;
                    //textInputPlayer2.inputField.text = answerText.text;
                    answerTextStr = textInputPlayer2.inputField.text;
                    Debug.Log("Player2の入力内容" + answerTextStr.ToString());

                    break;
                default:
                    playerCardList = null;
                    break;
            }
            //CardController[] playerCardList = KeepCardPlayer1Transform.GetComponentsInChildren<CardController>();
            //CardController[] player2CardList = KeepCardPlayer2Transform.GetComponentsInChildren<CardController>();
            Debug.Log("playerCardListの長さ：" + playerCardList.Length);
            //Debug.Log(playerCardList[1].model.letter);
            string[] playerLetterList = new string[playerCardList.Length];
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
                playerLetterList[i] = playerCardList[i].model.letter;
                Debug.Log(string.Join(",", playerLetterList));
                if (!answerTextStr.Contains(playerLetterList[i])) //ここここここここ！！！
                {
                    checkContainsLetter = CheckSpecialLetter(playerLetterList[i], answerTextStr);
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
            else
            {
                answerText.text = "";
            }
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

        Debug.Log("Spawn");
        CardController card = Instantiate(cardPrefab, SpawnFieldTransform, false);

        card.Init(deckNumber);
        float posX = spawnArea.position.x;
        float posY = spawnArea.position.y;
        cardPrefab.GetComponent<Transform>().position = new Vector2(posX, posY);
        //StartCoroutine(IntervalAnimation(spawnArea, card));
        //CardController cardController = 
        /*
        SpawnAnimation(spawnArea, card, posX, posY);
        card.transform.SetParent(spawnArea, false);
        
        */
        StartCoroutine(IntervalAnimation(spawnArea, card, posX, posY));
        if (deckNumber < 44)
        {
            deckNumber++;

        }
        else
        {
            Scoreing();
        }
    }
    void SpawnAnimation(Transform cardFieldTransform, CardController cardPrefab, float posX, float posY)
    {

        // カードの移動先を設定
        //float posX = (this.GridLayout.cellSize.x * this.mWidthIdx) + (this.GridLayout.spacing.x * (this.mWidthIdx + 1));
        //float posY = ((this.GridLayout.cellSize.y * this.mHelgthIdx) + (this.GridLayout.spacing.y * this.mHelgthIdx)) * -1f;

        // カードの初期値を設定 (画面外にする)
        //cardPrefab.mRt.anchoredPosition = new Vector2(1900, 0f);
        cardPrefab.GetComponent<Transform>().DOMove(new Vector2(posX, posY), 0.3f);
        GetComponent<AudioSource>().PlayOneShot(cardSpawnSound);
        // DOAnchorPosでアニメーションを行う
        //cardPrefab.mRt.DOAnchorPos(new Vector2(posX, posY), this.DEAL_CAED_TIME);
    }
    IEnumerator IntervalAnimation(Transform cardFieldTransform, CardController cardPrefab, float posX, float posY)
    {
        cardPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false;
        //ここに処理を書く
        SpawnAnimation(cardFieldTransform, cardPrefab, posX, posY);

        //1フレーム停止
        yield return new WaitForSeconds(0.2f);
        cardPrefab.transform.SetParent(cardFieldTransform, false);
        cardPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //SpawnAnimation(cardFieldTransform, cardPrefab);
        //ここに再開後の処理を書く
    }
    IEnumerator SpawnAllCards()
    {
        for (int i = 0; i < cardFieldTransform.Length;)
        {
            SpawnCard(cardFieldTransform[i]);
            Debug.Log(i);
            yield return new WaitForSeconds(0.3f);
            i++;
        }

    }

    void JudgeByOpponent(int playerNumber)
    {//判定ボタンの表示
        AcceptObjk = Instantiate(acceptButtonPrefab);
        AcceptObjk.transform.SetParent(canvas.transform, false);
        RejectObjk = Instantiate(rejectButtonPrefab);
        RejectObjk.transform.SetParent(canvas.transform, false);

        blockRaycast.GetComponent<Image>().raycastTarget = true;


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
    public void Scoreing()
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
