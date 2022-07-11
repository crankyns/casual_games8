using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_8 : MonoBehaviour
{
    public GameObject enemyPrefab, friendPrefab;

    int counter = 0;

    Vector2 startPos;
    void Start()
    {
        StartCoroutine(Spawn());
    }


    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            if(counter % 5 == 0)
            {
                startPos = new Vector2(2.7f, Random.Range(0.9f, -0.9f));
                Instantiate(friendPrefab, startPos,Quaternion.identity); 
            }
            else
            {
                startPos = new Vector2(2.7f, Random.Range(1f,-1f));
                Instantiate(enemyPrefab, startPos,Quaternion.identity);          
            }
            
            counter++;
            yield return new WaitForSeconds(1);
        }
    }
}
