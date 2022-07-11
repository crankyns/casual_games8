using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_4 : MonoBehaviour
{
    public GameObject enemyPrefab, friendPrefab;

    GameObject pref;

    int counter = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            float rand = Random.Range(0,2);
            float y;

            if(rand == 0)
                y = -1.5f;
            else 
                y = 1.5f;

            if(counter % 4 == 0)
                pref = friendPrefab;
            else
                pref = enemyPrefab;
        
            Vector2 startPos = new Vector2(Random.Range(3.3f, 3.7f), y);
            Instantiate(pref, startPos, Quaternion.identity);
            counter++;
            yield return new WaitForSeconds(1.5f);
        }
    }
}
