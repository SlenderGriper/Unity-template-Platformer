using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {
    private Text txt;
    string q;
    private void Start()
    {
        txt = GetComponent<Text>();
    }
    void Update () {
        txt.text = Full.money + "";
	}
}
