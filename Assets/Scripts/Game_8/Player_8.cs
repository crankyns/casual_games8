using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player_8 : MonoBehaviour
{
    bool sideFlag = false;

    public ParticleSystem deathParticle;

    public Text scoreText;
    int score = 0;
    int sideRotaion = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sideFlag = !sideFlag;
        }



        if(sideFlag)
            sideRotaion = 1;
        else
            sideRotaion = -1;


        transform.Rotate(0, 0, 180 * sideRotaion * Time.deltaTime, Space.World);
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
            
            Instantiate(deathParticle, transform.GetChild(0).transform.position, Quaternion.Euler(-90, 0, 0));
            Time.timeScale = 0;
            scoreText.text = "0";
            foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.GetComponent<Enemy_8>().toDestroy();
            }
            Destroy(gameObject);
        }
    }


}
