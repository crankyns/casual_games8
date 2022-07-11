using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    bool rotationFlag = false;
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            rotationFlag = !rotationFlag;
        }
        if(rotationFlag )
        {
            transform.Rotate(new Vector3(0,0,1) * Time.deltaTime * 120);
        }
        else
        {
            transform.Rotate(new Vector3(0,0,-1) * Time.deltaTime * 120);
        }

    }
     


}
