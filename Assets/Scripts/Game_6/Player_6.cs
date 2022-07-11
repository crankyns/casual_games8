using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_6 : MonoBehaviour
{

    Vector2 target;
    int up, right = 1;
    bool changeFlag = false;
    int score = 0;
    public Text scoreText;
    void Start()
    {
    
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            SceneManager.LoadScene(6);


        if(Input.GetKeyDown(KeyCode.Space) && (transform.position.y < 1.45f && transform.position.y > -1.45f))
            changeFlag = !changeFlag;

        if(!changeFlag )
           up = 1;
        else
            up = -1;

        if(transform.position.x > 2.64f)
            right = -1;
        else if(transform.position.x < -2.64f)
            right = 1;

        if(transform.position.y > 1.58f || transform.position.y < -1.58f)
        {
          changeFlag = !changeFlag;
            float y = -1;
            if(changeFlag!)
                y = 1;
            transform.position = new Vector2(transform.position.x,  transform.position.y - 0.05f * y);  
        }
            

        target = transform.position + (Vector3.right * right) + (Vector3.up * up);
            
        transform.position = Vector2.MoveTowards(transform.position, target , Time.deltaTime * 3f);        
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Friend")
        {
            score++;
            scoreText.text = score.ToString();
        }
        else
        {
            score = 0;
            scoreText.text = "0";
            SceneManager.LoadScene(5);
        }

    }
}
