using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OuterCircle : MonoBehaviour
{
    public GameObject enemy;
    float startDistance;

    int enemyCounter = 0;
    void Start()
    {
        startDistance = (Vector2.Distance(transform.GetChild(0).transform.position, Vector2.zero));
        StartCoroutine(CreateEnemy());
    }

    void Update()
    {
        
    }

    public IEnumerator CreateEnemy()
    {
        while(true)
        {
            yield return new WaitUntil(() => transform.childCount == 0);
            yield return new WaitForSeconds(0.6f);
            Vector2 pos = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f,2.5f)).normalized * startDistance;
            transform.rotation = Quaternion.Euler(0,0,0);
            GameObject createdEnemy = Instantiate(enemy, pos, Quaternion.identity);
            createdEnemy.transform.SetParent(transform);
            if(enemyCounter > 1)
                StartCoroutine(Move());
            enemyCounter++;
        }

    }

    public IEnumerator Move()
    {
        yield return new WaitForSeconds(0.3f);
        Quaternion startPos = transform.rotation;
        float startRotationZ = transform.rotation.z;
        float _timePassed = 0;
        float mult = 0.7f;

        int[] arr = new int[2] {1, -1};
        int sideRotation = arr[Random.Range(0, 2)];
        Quaternion target = Quaternion.Euler(0, 0, 65 * sideRotation);



        while(transform.rotation != target && transform.childCount != 0)
        {
        
            if(_timePassed < 0.9)
                _timePassed += Time.deltaTime * mult;
            else
                mult -= 0.005f;
                _timePassed += Time.deltaTime * mult;
            // _timePassed += Time.deltaTime * mult;
            float t = _timePassed * _timePassed;

            
            transform.rotation = Quaternion.Slerp(startPos, target, t);
            yield return null;

        }


        

    }


}
