using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text>();
    }

    public void InputText()
    {
        //text.text = inputField.text;
        Debug.Log("Type: " + inputField.text.GetType());
        //テキストにinputFieldの内容を反映

    }
}
