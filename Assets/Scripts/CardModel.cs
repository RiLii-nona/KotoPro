using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel
{
    public string letter; //文字
    public int type; //カードの形をint型で取得
    public Sprite shape; //カードの形
    public string[] letterArray = { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "や", "ゆ", "よ", "ら", "り", "る", "れ", "ろ", "わ" };
    public int[] typeArray = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    public string[] letterArray2 = { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "や", "ゆ", "よ", "ら", "り", "る", "れ", "ろ", "わ" };
    public int[] typeArray2 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };

    //Sprite[] image = Resources.LoadAll<Sprite>("Piece");



    /*
    public CardModel(int cardID){
            CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card"+cardID);

                letter = cardEntity.letter;
                type = cardEntity.type;
                shape = cardEntity.shape;
        }
    */
    void Awake()
    {
        //CardShuffle();

    }
    /*
    
    */
    public CardModel(int cardID)
    {
        //CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);

        CardShuffle(cardID);
        Debug.Log("Letterの配列長" + letterArray.Length);
        Debug.Log("Typeの配列長" + typeArray.Length);
        letter = letterArray[cardID];
        type = typeArray[cardID];
        if (type == 1)
        {
            shape = Resources.Load<Sprite>("Image/Piece/starPiece");
        }
        if (type == 2)
        {
            shape = Resources.Load<Sprite>("Image/Piece/circlePiece");
        }
        if (type == 3)
        {
            shape = Resources.Load<Sprite>("Image/Piece/hexagonalPiece");
        }
        if (type == 4)
        {
            shape = Resources.Load<Sprite>("Image/Piece/blossomPiece");
        }
        //shape = cardEntity.shape;
    }
    void CardShuffle(int cardID)
    {
        for (int i = cardID; i < letterArray.Length; i++)
        {
            string tempLetter = letterArray[i]; // 現在の要素を預けておく
            int randomIndexLetter = Random.Range(0, letterArray.Length); // 入れ替える先をランダムに選ぶ
            letterArray[i] = letterArray[randomIndexLetter]; // 現在の要素に上書き
            letterArray[randomIndexLetter] = tempLetter; // 入れ替え元に預けておいた要素を与える

            int tempType = typeArray[i]; // 現在の要素を預けておく
            int randomIndexType = Random.Range(0, typeArray.Length); // 入れ替える先をランダムに選ぶ
            typeArray[i] = typeArray[randomIndexType]; // 現在の要素に上書き
            typeArray[randomIndexType] = tempType; // 入れ替え元に預けておいた要素を与える

        }
    }

}
