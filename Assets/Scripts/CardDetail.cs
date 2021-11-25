using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDetail : MonoBehaviour
{
    public string[] letterArray = { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "や", "ゆ", "よ", "ら", "り", "る", "れ", "ろ", "わ" };
    public int[] typeArray = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };

    // Start is called before the first frame update
    void Start()
    {
        CardShuffle();
    }

    // Update is called once per frame
    void CardShuffle()
    {
        for (int i = 0; i < letterArray.Length; i++)
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
