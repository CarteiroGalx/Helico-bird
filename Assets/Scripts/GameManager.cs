using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public List<GameObject> Pipes;
    public float velocityPipes = 1;
    [HideInInspector]
    public int score;
    public float interval = 1;
    private float cooldown;

    [HideInInspector]
    public float gameHeigth = 4;
    //Altura máxima dos canos por unidades

    // Start is called before the first frame update
    void Start()
    {
        cooldown = interval;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= 1 * Time.deltaTime;
        if(cooldown <= 0){
            SpawnPipe();
            cooldown = interval;
        }
    }

    private void SpawnPipe(){
        int PipeIndex = Random.Range(0, Pipes.Count);
        GameObject SelectedPipe = Pipes[PipeIndex];
        Instantiate(SelectedPipe, new (20, Random.Range(-gameHeigth / 2, gameHeigth /2), -1), transform.rotation);
    }
}
