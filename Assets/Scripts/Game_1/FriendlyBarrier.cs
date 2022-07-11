using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyBarrier : MonoBehaviour
{

    public ParticleSystem particle;

    Vector2 positionStart;

    MainProcess mainProcess;

    

    void Start()
    {
        mainProcess = FindObjectOfType<MainProcess>();
        positionStart = transform.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y) + Vector2.down, Time.deltaTime * 1);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        ParticleSystem effect = Instantiate(particle, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.Euler(-90, 0, 0));
        Destroy(effect, 1f);
        MainManager.score ++;
        mainProcess.updateUI();
        Time.timeScale += 0.1f;
        Destroy(gameObject);
    }
  
}
