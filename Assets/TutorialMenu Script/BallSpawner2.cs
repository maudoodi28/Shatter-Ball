using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner2 : MonoBehaviour
{
    public static BallSpawner2 StartInstance;
    public GameObject[] balls;
    int X = 1;
    void Awake()
    {
        StartInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        X = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ballSpawner()
    {
        int rand;
        if (X<=2)
        {
            rand = 0;
            X++;
        }
        else
        {
            rand = 1;
            X = 1;
        }
        
        Instantiate(balls[rand], transform.position, transform.rotation);

    }
    IEnumerator ballSpawn()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            ballSpawner();
            yield return new WaitForSeconds(1.5f);
        }
    }
    public void StartSpawningBall()
    {
        StartCoroutine("ballSpawn");
    }
    public void StopSpawningBall()
    {
        StopCoroutine("ballSpawn");
    }
}
