using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMoney : MonoBehaviour {
    private float speed = -1f, Pos1 = 0f,Pos2=50f,money=Full.money,q=0;
    private RectTransform rect;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        if (rect.offsetMin.y != Pos1&&q>0)
        {
            rect.offsetMin += new Vector2(rect.offsetMin.x, speed);
            rect.offsetMax += new Vector2(rect.offsetMax.x, speed);
        }
        if (rect.offsetMin.y != Pos2&&q<0)
        {
            rect.offsetMin -= new Vector2(rect.offsetMin.x, speed);
            rect.offsetMax -= new Vector2(rect.offsetMax.x, speed);
        }
        if (Full.money!=money)
        {
            money = Full.money;
            q = 5;
        }
        q -= 0.02f;
    }
}
