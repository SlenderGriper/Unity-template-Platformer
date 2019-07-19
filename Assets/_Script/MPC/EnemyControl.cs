using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    private float offset = 1.5f;
        public float speed=0.1f;
    bool flip = false,Left=true,Right=false;
    SpriteRenderer Pl;
     void Start()
    {
      Pl = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        //код для проверки что внизу ничего нет 
        float x = transform.position.x + offset;
        float y = transform.position.y - 1.42f; //размер объекта 1, и чтоб он не находил лучом сам себя вычитаем чуть больше половины ( в низ )
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(x, y), -Vector2.up, 3f);
        RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(transform.position.x+1.5f, transform.position.y), Vector2.left, 1.5f);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x-1.5f, transform.position.y), -Vector2.left, 1.5f);
        if (hit.collider == null) {
            speed = -speed;
            offset = -offset;
            flip = !flip;
            Pl.flipX = flip;
            Left = !Left;
            Right = !Right;
            
        }   
        else if (hit.collider != null) transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        if (hit1.collider.tag == "Ground"&&Left) {
            speed = -speed;
            offset = -offset;
            flip = !flip;
            Pl.flipX = flip;
            Left = !Left;
            Right = !Right;
        }
        if (hit2.collider.tag == "Ground" && Right)
        {
            speed = -speed;
            offset = -offset;
            flip = !flip;
            Pl.flipX = flip;
            Left = !Left;
            Right = !Right;
        }
    }

}
