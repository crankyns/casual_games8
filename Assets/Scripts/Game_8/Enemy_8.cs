using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_8 : MonoBehaviour
{
    public float speed = 5f;

    bool isFriend = false;

    void Start()
    {
        if(gameObject.tag == "Friend")
            isFriend = true;
    }


    void Update()
    {
        
        



        if(transform.position.x <= -2.7f)
            Destroy(gameObject);

        if(isFriend)
            transform.Rotate(0, 0, 90 * Time.deltaTime);

        transform.position += Vector3.left * Time.deltaTime * speed;
    }

    IEnumerator scaling()
    {
        yield return new WaitForSecondsRealtime(1f);
        while(transform.localScale.x > 0.001)
        {
            Vector3 scaleChange = new Vector3(0.016f, 0.008f, 0.004f);
            transform.localScale -= scaleChange;
            yield return null;
        }
        Destroy(gameObject);
        Time.timeScale = 1;
        SceneManager.LoadScene(6);

    }

    public void toDestroy()
    {
        StartCoroutine(scaling());
    }
}
