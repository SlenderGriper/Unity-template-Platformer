using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {
    public GameObject[] door;
    void Start()
    {
        int a = door.Length;
        for (int i = 0; i < a; i++)
        {
            if (Full.floor == i) {
                transform.position = door[i].transform.position;
                 transform.position = new Vector3(transform.position.x, transform.position.y-1f, -0.1f);
                    }
        }
    }
}
