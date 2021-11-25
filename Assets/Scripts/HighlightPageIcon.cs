using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightPageIcon : MonoBehaviour
{
    public GameObject[] IconPosition;
    public GameObject firstHighlightIcon;
    public GameObject highlightIcon, normalIcon;
    public bool dragFirst = true;

    //int absPageIndex;
    /*
    public void ChangeIcon()
        {
            PageScrollRect pageScrollRect = gameObject.GetComponent<PageScrollRect>();
            int pageIndex = pageScrollRect.pageIndex;
            Debug.Log(pageIndex);

            Vector3 fieldPos;
            DrawNormalIcon();
            absPageIndex = Math.Abs(pageIndex);

            if (pageIndex <= 0)
            {
                fieldPos = IconPosition[0].transform.position;
            }
            else
            {
                fieldPos = IconPosition[absPageIndex].transform.position;
            }
            Instantiate(highlightIcon, fieldPos, Quaternion.identity);

        }
        void DrawNormalIcon()
        {
            for (int i = 0; i < IconPosition.Length; i++)
            {
                Vector3 fieldPos = IconPosition[i].transform.position;
                Instantiate(normalIcon, fieldPos, Quaternion.identity);
            }
        }
    */


}
