using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player_5 : MonoBehaviour
{
    bool rotationFlag = false;

    public Text scoreText;

    int score = 0;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            SceneManager.LoadScene(5);

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            rotationFlag = !rotationFlag;
        }
        if(rotationFlag )
        {
            transform.Rotate(new Vector3(0,0,1) * Time.deltaTime * 120);
        }
        else
        {
            transform.Rotate(new Vector3(0,0,-1) * Time.deltaTime * 120);
        }

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
            SceneManager.LoadScene(4);
        }

    }


}