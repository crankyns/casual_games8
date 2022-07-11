using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrier : MonoBehaviour
{
    Vector2 positionStart;

    float speed;
    float moveSide;
    float _timePassed;
    
    float speedMovingX;
    void Start()
    {
        speedMovingX = Random.Range(0f, 0.002f);

        positionStart = transform.position; 
        if (gameObject.name == "LeftBarrier")
        {
            moveSide = 1f;
        }
        else
        {
            moveSide = -1f;
        }

    
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            SceneManager.LoadScene(1);

        _timePassed += Time.deltaTime - speedMovingX;
        if (Time.timeScale != 0)
            transform.position = Vector2.Lerp(positionStart, positionStart + new Vector2(moveSide, 0f), Mathf.PingPong(_timePassed, 1));

        positionStart = Vector2.MoveTowards(positionStart, positionStart + Vector2.down, Time.deltaTime * 1);
        if(transform.position.y <= -5.1f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            Time.timeScale = 0;
            FindObjectOfType<MainProcess>().updateUI("Your score\n");
            StartCoroutine(NewRun());
    }

    IEnumerator NewRun()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
