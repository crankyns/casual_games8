using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class MainProcess : MonoBehaviour
{
    public GameObject[] barriers = new GameObject[3];

    public Text scoreText;

    bool flag = false; //allow to create red barrier
    int flagTime = 0; //check is the same second in update 

    List<int> PSRarray = new List<int>(2);   //pseudorandom array
    void Start()
    {

        StartCoroutine(CreateBarrier());
        
    }

    void Update()
    {
        

        if (Mathf.FloorToInt(Time.realtimeSinceStartup) % 10 == 0 && Mathf.FloorToInt(Time.realtimeSinceStartup) != flagTime)            
            flag = true;
    }


    IEnumerator CreateBarrier()
    {
        yield return new WaitForSeconds(1);

        while(true)
        {
            int index = Check(Random.Range(0,2));
            Instantiate(barriers[index]);
            if (flag)
            {
                flag = false;
                flagTime = Mathf.FloorToInt(Time.realtimeSinceStartup);
                StartCoroutine(CreateFriendly());
            }
            yield return new WaitForSeconds(Random.Range(2f, 2.5f));

        }

    }

    IEnumerator CreateFriendly()
    {
        yield return new WaitForSeconds(1);
        Instantiate(barriers[2]);

    }

    int Check(int index)
    {
        PSRarray.Add(index);          
        if (PSRarray.SequenceEqual(new List<int>() {1, 1, 1}))
        {   
            PSRarray.Add(0);
            PSRarray.RemoveRange(0,2);
            return 0;
        }
        else if (PSRarray.SequenceEqual(new List<int>() {0, 0, 0}))
        {
            PSRarray.RemoveRange(0,2);
            PSRarray.Add(1);
            return 1;
        }   
        if (PSRarray.Count == 3) 
        PSRarray.RemoveAt(0);
        return index;
    }

    public void updateUI(string isEnd = "")
    {

        scoreText.text = isEnd + MainManager.score.ToString();
    }

}

