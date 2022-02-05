using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
//using DG.Tweening;

public class ToMainScene : MonoBehaviour
{

    public void OnClickToMainButton()
    {
        StartCoroutine("LoadSceneAfterAnimation");
    }
    // Update is called once per frame
    IEnumerator LoadSceneAfterAnimation()
    {
        this.transform.DOScale(1.1f, 1.0f).SetEase(Ease.OutElastic);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("MainScene");
    }
}
