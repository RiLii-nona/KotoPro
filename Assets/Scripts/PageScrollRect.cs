using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// ページスクロールビュー.
public class PageScrollRect : ScrollRect
{
    // 1ページの幅.
    private float pageWidth;
    // 前回のページIndex. 最も左を0とする.
    private int prevPageIndex = 0;
    [SerializeField] GameObject[] IconPosition;
    [SerializeField] GameObject highlightIcon, normalIcon;
    HighlightPageIcon highlightPageIcon;

    int absPageIndex;
    GameObject InstantiateObj;
    Vector3 fieldPos;



    //public int pageIndex;


    protected override void Awake()
    {
        base.Awake();

        GridLayoutGroup grid = content.GetComponent<GridLayoutGroup>();
        // 1ページの幅を取得.
        pageWidth = grid.cellSize.x + grid.spacing.x;


    }

    // ドラッグを開始したとき.
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
    }

    // ドラッグを終了したとき.
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        // ドラッグを終了したとき、スクロールをとめます.
        // スナップさせるページが決まった後も慣性が効いてしまうので.
        StopMovement();

        // スナップさせるページを決定する.
        // スナップさせるページのインデックスを決定する.
        int pageIndex = Mathf.RoundToInt(content.anchoredPosition.x / pageWidth);
        // ページが変わっていない且つ、素早くドラッグした場合.
        // ドラッグ量の具合は適宜調整してください.
        if (pageIndex == prevPageIndex && Mathf.Abs(eventData.delta.x) >= 5)
        {
            pageIndex += (int)Mathf.Sign(eventData.delta.x);
            Debug.Log("aaa");
        }

        // Contentをスクロール位置を決定する.
        // 必ずページにスナップさせるような位置になるところがポイント.
        float destX = pageIndex * pageWidth;
        content.anchoredPosition = new Vector2(destX, content.anchoredPosition.y);

        // 「ページが変わっていない」の判定を行うため、前回スナップされていたページを記憶しておく.
        prevPageIndex = pageIndex;
        Debug.Log(pageIndex);
        ChangeIcon(pageIndex);
        //gameManager.GetComponent<HighlightPageIcon>().ChangeIcon(pageIndex);
    }

    public void ChangeIcon(int pageIndex)
    {
        HighlightPageIcon highlightPageIcon = gameObject.GetComponent<HighlightPageIcon>();

        Debug.Log(pageIndex);


        //DrawNormalIcon();
        absPageIndex = Math.Abs(pageIndex);
        if (highlightPageIcon.dragFirst == true)
        {
            Destroy(highlightPageIcon.firstHighlightIcon);
            highlightPageIcon.dragFirst = false;
        }
        if (pageIndex >= 0)
        {
            fieldPos = highlightPageIcon.IconPosition[0].transform.position;
        }
        else
        {
            fieldPos = highlightPageIcon.IconPosition[absPageIndex].transform.position;
        }
        Destroy(InstantiateObj);
        InstantiateObj = Instantiate(highlightPageIcon.highlightIcon, fieldPos, Quaternion.identity);
        InstantiateObj.GetComponent<SpriteRenderer>().sortingLayerName = "Icon Layer";

    }
    void DrawNormalIcon()
    {
        for (int i = 0; i < highlightPageIcon.IconPosition.Length; i++)
        {
            Vector3 fieldPos = highlightPageIcon.IconPosition[i].transform.position;
            Instantiate(highlightPageIcon.normalIcon, fieldPos, Quaternion.identity);
        }
    }
}