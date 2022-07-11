using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_6 : MonoBehaviour
{
    public float speed = 1.3f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
        if(transform.position.y <= -1.75f)
            Destroy(gameObject);
    }

    IEnumerator scaling()
    {
        while(transform.localScale.x > 0.001)
        {
            Vector3 scaleChange = new Vector3(0.004f, 0.004f, 0.004f);
            transform.localScale -= scaleChange;
            yield return null;
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(scaling());
    }
}
