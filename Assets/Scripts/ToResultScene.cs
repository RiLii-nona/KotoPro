using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;







//CheckListのplayerNumを取ってきたほうがいいかもGetPlayerするんじゃなくて。








public class ToResultScene : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用

    public static int[] player1ScoreList, player2ScoreList;
    private Text player1ScoreStr, player2ScoreStr;
    //[SerializeField]　
    [SerializeField] Text Player1Type1Score;
    [SerializeField] GameObject timer;
    float time;


    // Use this for initialization
    void Start()
    {
        player1ScoreList = new int[4];
        player2ScoreList = new int[4];
        time = 0.0f;       // 経過時間初期化

    }

    // Update is called once per frame
    void Update()

    {
        time = timer.GetComponent<CountDownTime>().totalTime;
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 3秒後に画面遷移（scene2へ移動）
        if (time <= 0.0f)
        {
            SetScore();
            SceneManager.LoadScene("ResultScene");
        }
    }

    public void SetScore()
    {
        for (int i = 1; i <= 4; i++)
        {

            player1ScoreStr = GameObject.Find("Player1Type" + i + "Score").GetComponent<Text>();
            Debug.Log("player1ScoreStr" + player1ScoreStr.text.ToString());
            player1ScoreList[i - 1] = Convert.ToInt32(player1ScoreStr.text.ToString());
            Debug.Log("player1ScoreList" + player1ScoreList[i - 1]);

            player2ScoreStr = GameObject.Find("Player2Type" + i + "Score").GetComponent<Text>();
            //Debug.Log(player2ScoreStr);
            player2ScoreList[i - 1] = Convert.ToInt32(player2ScoreStr.text.ToString());


        }
        Debug.Log(string.Join(",", player1ScoreList));
    }
}