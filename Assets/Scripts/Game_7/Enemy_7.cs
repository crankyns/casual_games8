using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_7 : MonoBehaviour
{

    public float speed = 3f;

    bool isFriend = false;
    void Start()
    {
        if(gameObject.tag == "Friend")
            isFriend = true;
    }


    void Update()
    {
        if(transform.position.y < -5.5f)
            Destroy(gameObject);
        if(isFriend)
            transform.Rotate(0, 0, 0.5f);
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
}
