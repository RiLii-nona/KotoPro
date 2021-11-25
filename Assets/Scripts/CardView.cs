using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Text letterText;
    [SerializeField] Image shapeImage;

    public void Show(CardModel cardModel){
        letterText.text = cardModel.letter;
        shapeImage.sprite = cardModel.shape;

    }
}
