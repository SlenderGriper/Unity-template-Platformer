using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public int function;
    private int NewGame = 0, Exit = 1, OpenSection = 2, OpenMenu = 3, ExitPause = 4,Continue=5;
    public GameObject off, on;
void OnMouseEnter()
    {
        GetComponent<Image>().color = new Color(0, 256, 0);
        transform.localScale = new Vector2(1.2f,1.2f);
    }
    void OnMouseExit()
    {
        transform.localScale = new Vector2(1f,1f);
        GetComponent<Image>().color = new Color(256, 256, 256);
    }
    void OnMouseDown()
    {
        GetComponent<Image>().color = new Color(256, 256, 256);
        if (function == NewGame)
        {
            SceneManager.LoadScene(1);
            Full.level = 1;
    Full.floor = 0;
}
        if(function==Exit)
         Application.Quit();
        if (function == OpenSection)
        {
           off.gameObject.SetActive(false);
           on.gameObject.SetActive(true);
        }
        if (function == OpenMenu)
        {
            Time.timeScale = 1;
            on.gameObject.SetActive(false);
            Pause.paused = false;
        }
        if (function == ExitPause)
        {
            Time.timeScale = 1;
            on.gameObject.SetActive(false);
            Pause.paused = false;
            SceneManager.LoadScene(0);
        }
        if (function == Continue)
        {
          SceneManager.LoadScene(Full.level);
        }
        }


    }

