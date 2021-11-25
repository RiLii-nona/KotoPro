using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ToExplanationScene : MonoBehaviour
{

    public void OnClickToExplanationButton()
    {
        SceneManager.LoadScene("ExplanationScene");
    }


    // Update is called once per frame

}
