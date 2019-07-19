using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
   private float hp = 100f;
    public Slider slider;

    void Update () {
        slider.value = hp;
        if (hp <= 0)
        {

            SceneManager.LoadScene("Game Over");
        }
	}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            hp--;
        }
    }
}
