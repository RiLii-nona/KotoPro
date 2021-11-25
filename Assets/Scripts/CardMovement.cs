using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    RectTransform canvas;
    public Transform defaultParent;
    //public Transform[] pastParent = new Transform[8];

    Camera cam;
    int i = 0;

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        cam = Camera.main;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {


        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false);
        //pastParent = pastParent.Concat(new Transform[] { transform.parent }).ToArray();
        //i = acceptButton.GetComponent<JudgeButtunAction>().i;
        //acceptButton.GetComponent<JudgeButtunAction>().GetPastParent(defaultParent);

        //i++;
        Debug.Log(i);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas, eventData.position, cam, out pos);
        transform.position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

}
