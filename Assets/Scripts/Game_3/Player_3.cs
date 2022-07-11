using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_3 : MonoBehaviour
{

    public Text scoreText;
    bool changeSide = true;
    float speed = 2;

    int score = 0;

    void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            SceneManager.LoadScene(3);

        if(Input.GetKeyDown(KeyCode.Space) && (transform.position.x > -1.5f && transform.position.x < 1.5f))
            changeSide = !changeSide;
        
        if(transform.position.x < -1.75f)
        {
            transform.position = new Vector2(-1.749f, 0);
            changeSide = !changeSide;
        }
        else if( transform.position.x > 1.75f)
        {
            transform.position = new Vector2(1.749f, 0);
            changeSide = !changeSide;
        }



    }

    IEnumerator Move()
    {
        while(true)
        {
            if(changeSide)
                transform.position = transform.position + new Vector3(1 * Time.deltaTime * speed, 0, 0);
            else
                transform.position = transform.position + new Vector3(-1 * Time.deltaTime * speed, 0, 0);
            yield return null;
        }
    }


    void OnTriggerEnter2D(Collider2D other)     
    {
        if(other.gameObject.tag == "Friend")
        {
            score++;
            scoreText.text = score.ToString();
        }
        if(other.gameObject.tag == "Enemy")
        {
            score = 0;
            SceneManager.LoadScene(2);

        }

            
    }

        // IEnumerator NewRun()
        // {
        //     Time.timeScale = 0;
        //     yield return new WaitForSecondsRealtime(1.5f);
        //     print("time gone");
        //     Time.timeScale = 1;
        //     SceneManager.LoadScene(1);

        // }
}
