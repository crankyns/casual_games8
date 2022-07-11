using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public ParticleSystem particle;
    void Start()
    {
        StartCoroutine(scaling());
    }


    void Update()
    {
 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        var effect = Instantiate(particle, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(effect,1.3f);
  
        Destroy(gameObject);
    }

    IEnumerator scaling()
    {   
        while(transform.localScale.x < 0.06967087)
        {
            Vector3 scaleChange = new Vector3(0.004f, 0.004f, 0.004f);
            transform.localScale += scaleChange;
            yield return null;
        }
    }
}
