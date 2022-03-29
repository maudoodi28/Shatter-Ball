using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBallSpawner : MonoBehaviour
{
    public static LBallSpawner LSPInstance;
    public GameObject[] balls;
    public static int SpeedSpawner = -1;
   // int SPscore = 12;
    float speed = 1.5f;
    public int bY;
    public float maxY;
    void Awake()
    {
        LSPInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSpawningBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpeedSpawner >= 0 && SpeedSpawner <= 5)
        {
            speed = 0.7f;
            if (SpeedSpawner == 0)
            {
                SpeedSpawner = -1;
            }
        }
        else
        {
            speed = 1.5f;
        }
    }
    void ballSpawner()
    {
        int rand = Random.Range(0, balls.Length);
        bY = rand;
        float randomY = Random.Range(5.13f, maxY);
        Vector3 RandomPos = new Vector3(transform.position.x, randomY, transform.position.y);
        Instantiate(balls[rand], RandomPos, transform.rotation);

    }
    IEnumerator ballSpawn()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            ballSpawner();
            yield return new WaitForSeconds(speed);
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
