using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimDoor : MonoBehaviour {
    private AudioSource AudioS;
    private bool input;
    public int level,position;
    private void Start()
    {
        AudioS = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (input == true && Input.GetKeyDown(KeyCode.Space) && !Full.jump)
        {//активация двери при нажатии пробела героя и нахождение героя в двери
            StartCoroutine(AnimationDoor());
            Full.stop = true;
            StartCoroutine(Begin());
            AudioS.Play();
            GetComponent<Animator>().SetBool("animate", true);
            Full.floor = position;
        }
    }
    void OnTriggerStay2D(Collider2D collision)//проверка на нахождение героя в двери
    {
        if (collision.gameObject.tag == "Player")
        {
            input = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            input = false;
        }
    }
    IEnumerator Begin()
    {
        yield return new WaitForSeconds(1f);
        Full.stop = false;
    }
    IEnumerator AnimationDoor()
    {
        Full.level = level;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);

    }
}
