using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ToExplanationScene : MonoBehaviour
{

    public void OnClickToExplanationButton()
    {
        StartCoroutine("LoadSceneAfterAnimation");

    }


    IEnumerator LoadSceneAfterAnimation()
    {
        this.transform.DOScale(1.1f, 1.0f).SetEase(Ease.OutElastic);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("ExplanationScene");
    }

}
