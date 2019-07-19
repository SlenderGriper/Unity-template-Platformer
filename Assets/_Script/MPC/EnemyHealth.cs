using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour {
   private float hp = 100f;
    public GameObject Money;
    void Update () {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "knife")
        {
            hp-=100f/3;
            Destroy(collision.gameObject);
        }
    }
}
