using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTextRaycast : MonoBehaviour
{
    [SerializeField] GameObject textBlockRaycast;
    public void InputTextRaycastOff(GameObject textBlockRaycast)
    {
        //inputField.GetComponent<Image>().raycastTarget = false;
        textBlockRaycast.GetComponent<Image>().raycastTarget = false;
    }

    public void InputTextRaycastOn(GameObject textBlockRaycast)
    {
        //inputField.GetComponent<Image>().raycastTarget = true;
        textBlockRaycast.GetComponent<Image>().raycastTarget = true;

    }

}
