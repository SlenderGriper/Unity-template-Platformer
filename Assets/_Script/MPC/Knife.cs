using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
    public float speed = 1f;
    public Vector2 L = -Vector2.left;
    private void Start()
    {
        StartCoroutine(DestroyKnife()); 
    }
    void Update () {
        transform.position = new Vector3(transform.position.x+speed, transform.position.y, transform.position.z);
        contact();
    }
    private void contact()
    {
        float x = transform.position.x;
        float y = transform.position.y+0.5f; 
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(x, y), L, 2f);
        if (hit.collider.tag != "enemy"&& hit.collider.tag != "Player" && !hit.collider.gameObject.GetComponent<Collider2D>().isTrigger)
        {
            print(hit.collider.gameObject.name + " " + hit.collider.gameObject.GetComponent<Collider2D>().isTrigger);
            Destroy(gameObject);
        }
    }
    IEnumerator DestroyKnife()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
