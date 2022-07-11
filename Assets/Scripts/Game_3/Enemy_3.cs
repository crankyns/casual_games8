using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_3 : MonoBehaviour
{

    Vector2 target;

    int sideRotation = 0;
    float speed = 2;
    void Start()
    {
        target = new Vector2(Random.Range(-2.3f, 2.3f), -2.7f);
        while(sideRotation == 0)
        {
            sideRotation = Random.Range(-1,2);
        }



    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.Rotate(0, 0, 40f * sideRotation * Time.deltaTime);
    }

    IEnumerator scaling()
    {
        while(transform.localScale.x > 0.07f)
        {
            Vector3 scaleChange = new Vector3(0.004f, 0.004f, 0.004f);
            transform.localScale -= scaleChange;
            yield return null;
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            Destroy(gameObject);
        StartCoroutine(scaling());
    }
}
