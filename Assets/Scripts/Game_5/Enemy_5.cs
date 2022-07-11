using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : MonoBehaviour
{
    Vector2 target;

    float speed = 1.2f;
    void Start()
    {
        if(gameObject.tag == "Friend")
            speed = 0.9f;
        target = new Vector2(Random.Range(-5f, 5f), Random.Range(-10f, 10f)).normalized * 3;
        StartCoroutine(scalingPlus());
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        StartCoroutine(scalingMinus());
    }

    IEnumerator scalingPlus()
    {
        while(transform.lossyScale.x < 0.2261931 )
        {
            Vector3 scaleChange = new Vector3(0.004f, 0.004f, 0.004f);
            transform.localScale += scaleChange;
            yield return null;
        }
    }

    IEnumerator scalingMinus()
    {
        while(transform.lossyScale.x > 0.001 )
        {
            Vector3 scaleChange = new Vector3(0.005f, 0.005f, 0.005f);
            transform.localScale -= scaleChange;
            yield return null;
        }
        Destroy(gameObject);
    }
}
