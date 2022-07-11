using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerCircle : MonoBehaviour
{

bool sideFlag = false;
int sideRotaion = 1;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && transform.childCount > 0)
        {
            sideFlag = !sideFlag;
            transform.GetChild(0).transform.SetParent(null);
        }



        if(sideFlag)
            sideRotaion = 1;
        else
            sideRotaion = -1;


        transform.Rotate(0, 0, 90 * sideRotaion * Time.deltaTime, Space.World);
    }

   private void OnTriggerEnter2D(Collider2D other) {
       
       other.gameObject.transform.SetParent(transform);
   }
}
