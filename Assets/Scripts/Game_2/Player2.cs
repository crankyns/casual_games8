using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Player2 : MonoBehaviour
{

    public Text score;
    Rigidbody2D rb;

    float startDistance;
    public int force = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        startDistance = (Vector2.Distance(transform.position, Vector2.zero));

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            SceneManager.LoadScene(2);

        if(Input.GetKeyDown(KeyCode.Space) && rb.velocity == Vector2.zero)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(transform.position * force, ForceMode2D.Impulse);
        }

        if(Vector2.Distance(transform.position, Vector2.zero) > 5)
            SceneManager.LoadScene(1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            score.text = (Int32.Parse(score.text) + 1).ToString();
            rb.velocity = Vector2.zero;
            rb.AddForce( -transform.position * force * 0.2f, ForceMode2D.Impulse);
        }

        if(other.name == "InnerCircle")
        {
            transform.position = transform.position.normalized * startDistance;
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;

        }
    }
}
