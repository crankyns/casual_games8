using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_7 : MonoBehaviour
{
    public GameObject enemy_1Pref, enemy_2Pref, friendPref;



    float[] spawnPoints = new float[5] {-2.3f, -1.15f, 0, 1.15f, 2.3f};

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
            int rand = Random.Range(0, 2);
            if(rand == 0)
            {
                Vector2 spawnPos = new Vector2(spawnPoints[Random.Range(1, 4)], 5.25f);
                Instantiate(enemy_2Pref, spawnPos, Quaternion.identity);
                if(counter % 5 == 0)
                {
                    rand = Random.Range(0,2);
                    if(spawnPos.x > 0 && rand == 1)
                        spawnPos = new Vector2(spawnPos.x - 2.3f, spawnPos.y);
                    else if(spawnPos.x <= 0 && rand == 1)
                        spawnPos = new Vector2(spawnPos.x + 2.3f, spawnPos.y);
                    Instantiate(friendPref, spawnPos, Quaternion.identity);
                }
                    
            }
            else
            {
                Vector2 spawnPos = new Vector2(spawnPoints[Random.Range(0, 5)], 5.25f);
                Instantiate(enemy_1Pref, spawnPos, Quaternion.identity);
                if(counter % 5 == 0)
                {
                    if(spawnPos.x >= 0)
                        spawnPos = new Vector2(spawnPos.x - 1.15f, spawnPos.y);
                    else
                        spawnPos = new Vector2(spawnPos.x + 1.15f, spawnPos.y);
                    Instantiate(friendPref, spawnPos, Quaternion.identity);

                }
            }
            counter++;
            yield return new WaitForSeconds(0.6f);
        }
    }
}
