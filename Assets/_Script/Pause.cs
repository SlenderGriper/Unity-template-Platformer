using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
 public static bool paused = false;
    public GameObject on;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                on.gameObject.SetActive(true);
                paused = true;
            }
    else
            {
                Time.timeScale = 1;
                on.gameObject.SetActive(false);
                paused = false;
            }
           
        }
    }
}
