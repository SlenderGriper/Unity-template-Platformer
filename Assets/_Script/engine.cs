using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Full
{
    public static int money = 0;    
    public static int level = 0;
    public static int floor=0;//позиция появления
    public static bool stop = false;//обездвиживает игрока
    public static bool jump = false;
}
public class Engine : MonoBehaviour {
    private static bool eng = false;
    private void Start()
    {
        if (!eng)
        {
            DontDestroyOnLoad(gameObject);
            eng = true;
        }
    }
}
