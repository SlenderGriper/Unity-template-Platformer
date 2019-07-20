﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private float speed=0.2f,powerJump,timeJump;
    private bool OnGround,jump,OneJump=false, recharge=false,rotateRigth=true,rotateRigthCheck=true;
    public GameObject knife;
    private Vector3 rotation,scaleRotate;
    public Transform checkGround;
    public LayerMask layerGround;
    private void Start()
    {

    }

    void Update () {
        Attack();
        StepLeft();
        StepRight();
        StopWalk();
        PressingTheButtonJump();
        ControleJump();
        RotateControle();
        Console.Write(OnGround);
    }

    void OnTriggerStay2D(Collider2D X)
    {

        if (X.gameObject.tag == "coin")
        {
            Destroy(X.gameObject);
            coin();
        }
    }
    void  ControleJump()
    {
        OnGround = Physics2D.OverlapCircle(checkGround.position, 0.25f , layerGround);
        if (OnGround && !OneJump && jump && !Full.stop)//прыжок
        {
            StartCoroutine(Jump());
        }

        if (OnGround)
        {
            GetComponent<Animator>().SetBool("foll", false);
            GetComponent<Animator>().SetBool("jump", false);
            Full.jump = false;
        }
        else
        {
            GetComponent<Animator>().SetBool("foll", true);
            Full.jump = true;
            if (jump)
                GetComponent<Animator>().SetBool("jump", true);
        }
    }

    IEnumerator Jump()
    {
        OneJump = true;

        for (int i = 0; i < 15; i++)
        {   
            yield return new WaitForSeconds(0.01f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        }
        jump = false;

        if (powerJump >= 0.15f) powerJump = 0.2f;

        timeJump = Mathf.Round(100f * powerJump);

        for (int i = 0; i < timeJump; i++)
        {
            yield return new WaitForSeconds(0.01f);
            if (powerJump >= 0.15f) powerJump = 0.15f;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        }

        Console.Write(powerJump+' '+1f * powerJump);
        OneJump = false;
        powerJump = 0;
    }

    void StepLeft()
    {
        if ( (Input.GetKey(KeyCode.A)) && !Full.stop)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            
            GetComponent<Animator>().SetBool("walk", true);
            rotateRigth = false;
        }
    }

    void StepRight()
    {
        if ((Input.GetKey(KeyCode.D)) && !Full.stop)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            
            GetComponent<Animator>().SetBool("walk", true);
            rotateRigth = true;
        }
    }
    void coin()
    {
        Full.money++;
    }
    void StopWalk()
    {
        if (!( (Input.GetKey(KeyCode.A))) && !( (Input.GetKey(KeyCode.D))) || Full.stop)//остановка ходьбы
        {
            GetComponent<Animator>().SetBool("walk", false);
        }
    }

    void PressingTheButtonJump()
    {
        if ((Input.GetKeyDown(KeyCode.W))&&OnGround)
        {
            jump = true;
        }
        if ((Input.GetKey(KeyCode.W))&&jump)
        {
            powerJump += Time.deltaTime;
        }
        else if ( !Input.GetKey(KeyCode.W))
        {
            jump = false;
        }
    }
void Attack()
    {
        if (Input.GetKey(KeyCode.J)) {
            Instantiate(knife);
            if (!rotateRigth)
            {
                knife.GetComponent<Knife>().speed = -1f;
                knife.GetComponent<Knife>().L = Vector2.left;
            }
            else
            {
                knife.GetComponent<Knife>().speed = 1f;
                knife.GetComponent<Knife>().L = -Vector2.left;
            }
            knife.transform.position = transform.position;
        }
    }
    void RotateControle()
    {
        if ((rotateRigth && !rotateRigthCheck)|| (!rotateRigth && rotateRigthCheck))
        {
            scaleRotate = transform.localScale;
            scaleRotate.x = -scaleRotate.x;
            transform.localScale = scaleRotate;
            rotateRigthCheck = !rotateRigthCheck;
        }
    }
}