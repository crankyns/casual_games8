using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_5 : MonoBehaviour
{

    public GameObject enemyPrefab, friendPrefab;

    int counter = 0;
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
                Instantiate(friendPrefab, transform.position, Quaternion.identity);
            else
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            counter++;
            yield return new WaitForSeconds(1f);

        }
    }
}
