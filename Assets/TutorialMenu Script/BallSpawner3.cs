using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner3 : MonoBehaviour
{
    public static BallSpawner3 StartInstance;
    public GameObject[] balls;
    void Awake()
    {
        StartInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ballSpawner()
    {
        int rand = Random.Range(0, balls.Length);
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
