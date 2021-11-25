using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int[] player1ScoreShape, player2ScoreShape, player1ScoreNotShape, player2ScoreNotShape;
    [SerializeField] GameObject[] player1ShapePlace, player2ShapePlace;
    [SerializeField] GameObject[] starPrefab, circlePrefab, hexagonPrefab, blossomPrefab;
    //[SerializeField] GameObject hexagon1Prefab;
    [SerializeField] RectTransform canvas;
    [SerializeField] Text player1ScoreText, player2ScoreText, player1Win, player2Win;
    int shapeSplit;
    int player1FocusArea = 0, player2FocusArea = 0;
    int player1Score = 0, player2Score = 0;
    private GameObject imageSetObj;
    private Sprite shapeImage;
    GameObject instantiateObj;
    Camera cam;
    void Start()
    {
        Debug.Log("ResultScene" + string.Join(",", ToResultScene.player2ScoreList));
        player1ScoreShape = new int[4];
        player2ScoreShape = new int[4];
        player1ScoreNotShape = new int[4];
        player2ScoreNotShape = new int[4];
        //hexagonPrefab = new GameObject[2];

        SetScoreShape(player1ScoreShape, player1ScoreNotShape);
        SetScoreShape(player2ScoreShape, player2ScoreNotShape);
        DisplayScore(player1ScoreShape, player1ScoreNotShape, player2ScoreShape, player2ScoreNotShape);




    }

    void SetScoreShape(int[] playerScoreShape, int[] playerScoreNotShape)
    {
        for (int i = 0; i < 4; i++) //{星, 丸, 六角, 桜}
        {
            if (i == 0)
            {
                shapeSplit = 5;
            }
            else if (i == 1)
            {
                shapeSplit = 2;
            }
            else if (i == 2)
            {
                shapeSplit = 6;
            }
            else
            {
                shapeSplit = 5;
            }
            player1ScoreShape[i] = ToResultScene.player1ScoreList[i] / shapeSplit;
            player1ScoreNotShape[i] = ToResultScene.player1ScoreList[i] % shapeSplit;
            player2ScoreShape[i] = ToResultScene.player2ScoreList[i] / shapeSplit;
            player2ScoreNotShape[i] = ToResultScene.player2ScoreList[i] % shapeSplit;
        }
        Debug.Log("player1ScoreShape" + string.Join(",", playerScoreShape));
        Debug.Log("player2ScoreShape" + string.Join(",", playerScoreNotShape));

        player1Score = player1ScoreShape[0] + player1ScoreShape[1] + player1ScoreShape[2] + player1ScoreShape[3];
        player2Score = player2ScoreShape[0] + player2ScoreShape[1] + player2ScoreShape[2] + player2ScoreShape[3];


    }

    void DisplayScore(int[] player1ScoreShape, int[] player1ScoreNotShape, int[] player2ScoreShape, int[] player2ScoreNotShape)
    {
        for (int i = 0; i < 4; i++) //{星, 丸, 六角, 桜}
        {
            Debug.Log("悪いところを探す！！！！！");
            Debug.Log("player1ShapePlace" + player1ShapePlace);
            Debug.Log("player1ScoreNotShape" + player1ScoreNotShape[i]);
            Debug.Log("player1FocusArea" + player1FocusArea);

            player1FocusArea = DisplayShape(player1ShapePlace, player1ScoreShape[i], player1FocusArea, true, i);   //点数になるoo
            player1FocusArea = DisplayShape(player1ShapePlace, player1ScoreNotShape[i], player1FocusArea, false, i);    //点数にならないoo

            player2FocusArea = DisplayShape(player2ShapePlace, player2ScoreShape[i], player2FocusArea, true, i);
            player2FocusArea = DisplayShape(player2ShapePlace, player2ScoreNotShape[i], player2FocusArea, false, i);

            player1ScoreText.text = player1Score.ToString() + "点";
            player2ScoreText.text = player2Score.ToString() + "点";
            if (player1Score > player2Score)
            {
                player1Win.text = "勝利";
            }
            else if (player1Score < player2Score)
            {
                player2Win.text = "勝利";
            }
            else
            {
                player1Win.text = "引き分け";
                player2Win.text = "引き分け";
            }

        }
    }

    int DisplayShape(GameObject[] playerShapePlace, int playerScoreShape, int playerFocusArea, bool completeShape, int shapeType)
    {
        while (playerScoreShape > 0)
        {
            imageSetObj = playerShapePlace[playerFocusArea];
            Vector3 fieldPos = imageSetObj.transform.position;
            if (completeShape)
            {
                Debug.Log("コンプリート");

                GameObject[] targetShape = shapeTypeToGameObject(shapeType);
                instantiateObj = targetShape[targetShape.Length - 1];
                Debug.Log(instantiateObj);
                Instantiate(instantiateObj, fieldPos, Quaternion.identity);

            }
            else
            {
                Debug.Log("ノットコンプリート");
                Debug.Log(playerShapePlace[playerFocusArea]);
                Debug.Log(playerScoreShape);
                Debug.Log(shapeTypeToString(shapeType) + playerScoreShape.ToString());
                shapeImage = Resources.Load<Sprite>(shapeTypeToString(shapeType) + playerScoreShape.ToString());
                //imageSetObj.GetComponent<Image>().sprite = Resources.Load<Sprite>(shapeTypeToString(shapeType) + playerScoreShape.ToString());
                GameObject[] targetShape = shapeTypeToGameObject(shapeType);
                instantiateObj = targetShape[playerScoreShape - 1];
                Instantiate(instantiateObj, fieldPos, Quaternion.identity);
                /*
                if (shapeType == 2)
                                {
                                    Debug.Log("六角形！！");
                                    //playerShapePlace[playerFocusArea] = hexagonPrefab[playerScoreShape - 1];

                                    instantiateObj = hexagonPrefab[playerScoreShape - 1];
                                    Debug.Log(hexagonPrefab[0]);

                                    Instantiate(instantiateObj, fieldPos, Quaternion.identity);

                                }

                */



                //imageSetObj = (GameObject)shapeTypeToString(shapeType) + playerScoreShape.ToString();

            }
            //imageSetObj.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //playerShapePlace[playerFocusArea].AddComponent<Image>().sprite = Resources.Load<Sprite>("starPiece");
            playerScoreShape--;
            playerFocusArea++;
            //Debug.Log(playerFocusArea);


        }
        return playerFocusArea;
    }

    string shapeTypeToString(int shapeType)
    {
        if (shapeType == 0) { return "star"; }
        else if (shapeType == 1) { return "circle"; }
        else if (shapeType == 2) { return "hexagon"; }
        else if (shapeType == 3) { return "blossom"; }
        else { return ""; }

    }

    GameObject[] shapeTypeToGameObject(int shapeType)
    {
        if (shapeType == 0) { return starPrefab; }
        else if (shapeType == 1) { return circlePrefab; }
        else if (shapeType == 2) { return hexagonPrefab; }
        else if (shapeType == 3) { return blossomPrefab; }
        else { return null; }

    }




}
