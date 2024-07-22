using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Obstacle : MonoBehaviour
{
    
    void Update()
    {
        transform.position += new Vector3(-GameManager.Instance.velocityPipes * Time.deltaTime, 0, 0);
        CheckPosition();
    }

    void CheckPosition(){
        if(transform.position.x <= -13){
            Destroy(gameObject);
        }
    }
}
