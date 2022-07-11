using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_4 : MonoBehaviour
{
    bool side = true;
    int speed = 6;

    public Text scoreText;
    int score = 0;
    void Start()
    {
            
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            SceneManager.LoadScene(4);

        float dist = Vector2.Distance(transform.position, new Vector2(0, 1.5247f));
        if(Input.GetKeyDown(KeyCode.Space) && (dist == 0 || dist == 3.0494f))
            side = !side;

        if(side)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, -1.5247f), Time.deltaTime * speed);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 1.5247f), Time.deltaTime * speed);
  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject);

        }

    }
}
