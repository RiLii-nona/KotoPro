using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleUpOrDown : MonoBehaviour
{
    // Start is called before the first frame update
    float time, changeSpeed;
    [SerializeField] float maxScale;
    bool enlarge;

    void Start()
    {
        enlarge = true;
    }

    void Update()
    {
        changeSpeed = Time.deltaTime * maxScale;

        if (time < 0)
        {
            enlarge = true;
        }
        if (time > 0.3f)
        {
            enlarge = false;
        }

        if (enlarge == true)
        {
            time += Time.deltaTime;
            transform.localScale += new Vector3(changeSpeed, changeSpeed, changeSpeed);
        }
        else
        {
            time -= Time.deltaTime;
            transform.localScale -= new Vector3(changeSpeed, changeSpeed, changeSpeed);
        }
    }
}
