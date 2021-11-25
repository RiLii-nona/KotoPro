using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTextRaycast : MonoBehaviour
{
    public void InputTextRaycastOff(InputField inputField)
    {
        inputField.GetComponent<Image>().raycastTarget = false;
    }

    public void InputTextRaycastOn(InputField inputField)
    {
        inputField.GetComponent<Image>().raycastTarget = true;
    }

}
