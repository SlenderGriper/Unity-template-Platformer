using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Continue : MonoBehaviour {
    int variable = 0, level = 0, floor = 0,money=0, w = 0;
    void Start () {
            StreamReader R = new StreamReader("Save.txt");
            string a = R.ReadLine();
            char q = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] != q) w = (int)a[i] - 48;
                if (a[i] == q) variable++;
                else if (variable == 0) level = level * 10 + w;
                else if (variable == 1) floor = floor * 10 + w;
                else if (variable == 2) money = money * 10 + w;

        }
            R.Close();
            Full.floor = floor;
            Full.level = level;
        Full.money = money;
    }
}
