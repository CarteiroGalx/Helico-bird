using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Blue_Obstacle : MonoBehaviour
{
    public float verticalSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-GameManager.Instance.velocityPipes * Time.deltaTime, 0, 0);
        transform.position += new Vector3(0, verticalSpeed * Time.deltaTime, 0);

        if(transform.position.y >= GameManager.Instance.gameHeigth / 2  || transform.position.y <= -GameManager.Instance.gameHeigth / 2){
            verticalSpeed *= -1;
        }

        CheckPosition();
    }

    void CheckPosition(){
        if(transform.position.x <= -13){
            Destroy(gameObject);
        }
    }
}
