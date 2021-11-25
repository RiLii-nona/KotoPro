using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToMainScene : MonoBehaviour
{

    public void OnClickToMainButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    // Update is called once per frame

}
