using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab, friendPrefab;

    int counter = 1;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            if(counter % 5 == 0)
                yield return StartCoroutine(SpawnFriend());
            Vector2 startPos = new Vector2(Random.Range(-2.5f, 2.5f), 5.5f);
            Instantiate(enemyPrefab, startPos, Quaternion.identity);
            counter++;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SpawnFriend()
    {
        Vector2 startPos = new Vector2(Random.Range(-2f, 2f), 5.5f);
        Instantiate(friendPrefab, startPos, Quaternion.identity);
        yield return new WaitForSeconds(1);
    }


}
