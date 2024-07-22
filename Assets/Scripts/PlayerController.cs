using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float forceJump = 10;
    public float rotationSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyJump = Input.GetKey(KeyCode.Space);

        if(keyJump){
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
            rb.AddForce(new(0, forceJump, 0), ForceMode.Acceleration);
        }
        else{
            transform.rotation = new(0, 90, 0, 0);
        }

    }

    void OnCollisionEnter(Collision other) {
        var score = GameManager.Instance.score;
        UnityEngine.Debug.Log("Eu encostei no:" + other.gameObject.name);
        
        if(other.gameObject.CompareTag("Obstacle")){
            UnityEngine.Debug.Log("GAME OVER...");
            Invoke("EndGame", 2);
            GameManager.Instance.velocityPipes = 0;
        }
    }

    void EndGame(){
        var sceneName =  SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
