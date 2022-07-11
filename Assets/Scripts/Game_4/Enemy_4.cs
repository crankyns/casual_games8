using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4 : MonoBehaviour
{
    int side = -1;
    void Start()
    {
        if(transform.position.y > 0)
            side = 1;

        StartCoroutine(UpsideDown());
    }


    void Update()
    {
        
    }

    IEnumerator UpsideDown()
    {
        Vector2 startPos = transform.position;
        float _timePassed = 0f;
        float speed = 1f;
        while(transform.position.x > -3.1f)
        {
            _timePassed += Time.deltaTime * speed;
            transform.position = Vector2.Lerp(startPos, startPos + Vector2.down * 3 * side, Mathf.PingPong(_timePassed, 1));
            startPos = Vector2.MoveTowards(startPos, startPos + Vector2.left * 2.3f, Time.deltaTime * 2f);
            yield return null;
        }
        Destroy(gameObject);
    }


}
