using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Text letterText;
    [SerializeField] Image shapeImage;

    public void Show(CardModel cardModel)
    {
        letterText.text = cardModel.letter;
        Font font = Resources.Load<Font>("Fonts/HannariMincho"); //Fontのロード
        letterText.GetComponent<Text>().font = font;
        shapeImage.sprite = cardModel.shape;

    }
}
