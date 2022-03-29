using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBallSpawner : MonoBehaviour
{
    public static MBallSpawner MSPInstance;
    public GameObject[] SPballs;
    public GameObject[] balls;
    public static int SpeedSpawner = -1;
    public static int SpecialSpawner;
    int SPscore = 15;
    float speed = 1.5f;
    public int bY;
    public float maxY;
    int SPx=0;
    void Awake()
    {
        MSPInstance = this;
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
        if(GameManager.Specialscore==SPscore)
        {
            SPx = 1;
            SPscore = SPscore+15;
        }
    }
    public void Specialspawner()
    {
        int SPrand = Random.Range(0, SPballs.Length);
        float randomSP = Random.Range(5.13f, maxY);
        Vector3 RandomPosSP = new Vector3(transform.position.x, randomSP, transform.position.y);
        Instantiate(SPballs[SPrand], RandomPosSP, transform.rotation);
        print("SpecialBall");
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
            if(SPx==1)

            {
                Specialspawner();
                SPx = 0;
            }
            else
            {
                ballSpawner();
            }
            
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
