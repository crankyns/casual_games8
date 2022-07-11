using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_6 : MonoBehaviour
{
    public GameObject enemyPrefab, friendPrefab;

    int counter = 0;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {

        while(true)
        {
            if(counter % 5 == 0)
                Instantiate(friendPrefab, new Vector2(Random.Range(-2.65f, 2.65f), 1.85f), Quaternion.identity);
            else
                Instantiate(enemyPrefab, new Vector2(Random.Range(-2.65f, 2.65f), 1.85f), Quaternion.identity);
            counter++;
            yield return new WaitForSeconds(2f);
        }
    }
}
