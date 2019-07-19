using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour {
    void Start () {
        FileStream Q = new FileStream("Save.txt", FileMode.OpenOrCreate);
        Q.Close();
        StreamWriter W = new StreamWriter("Save.txt");
        W.Write(" "+Full.level + " " + Full.floor+" "+Full.money);
        W.Close();
    }
}
 