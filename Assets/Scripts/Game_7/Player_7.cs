using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_7 : MonoBehaviour
{
 
    public float speed = 8f;

    public Text scoreText;

    int score = 0;
    Vector2 target;
    void Start()
    {
        target = transform.position;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            SceneManager.LoadScene(7);

        if(Input.GetKeyDown(KeyCode.LeftArrow) && (transform.position.x == 1.15f || transform.position.x == 0f))
            {
                target = new Vector2(transform.position.x - 1.15f, transform.position.y);
            }
        if(Input.GetKeyDown(KeyCode.RightArrow) && (transform.position.x == -1.15f || transform.position.x == 0f))
            {
                target = new Vector2(transform.position.x + 1.15f, transform.position.y);               
            }

        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Friend")
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject);
        }
        else
        {
            score = 0;
            scoreText.text = "0";
            SceneManager.LoadScene(6);
        }
    }
}
