using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBallSpawner : MonoBehaviour
{
    public GameObject[] balls;
    public int Spawner=0;
    public static int SpScore;
    public static int DestroyS=15;
    public static int DestroyBall=0;
    public static int ScoreBall;
    int max=0;
    int p = 1;
    int S = 15;
    int DestroyP = 0;
    public static PinBallSpawner PballSpawner;
    // Start is called before the first frame update
    void Start()
    {
        SpScore = 0;
        print("Pin Ball Spawner");
        StartPinBallSpawner();
        if(PballSpawner==null)
        {
            PballSpawner = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        PinBallScript.PinX = DestroyS;
        if (SpScore==S)
        {
            PinBallScript.PDestroy = DestroyP;
            S = S + 15;
            //print("S");
        }
        
    }
    public void pinballSpawner()
    {
        //print(SpScore);
       // print(max);
       // print(p);
        if (SpScore == max && p==1)
        {
            print("Pin Spawn");
            DestroyP = 1;
            int rand = Random.Range(0, balls.Length);
            int xx = rand;
            ScoreBall = xx;
            BoundaryScript.BdBall = xx;
            Instantiate(balls[rand], transform.position, transform.rotation);
            p = 0;
            max = max + 15;
            //print(max);
            
            //print("instantiate");
        }
        if(DestroyBall==1)
        {
            p = 1;
            DestroyBall = 0;
        }
        
    }
    IEnumerator pinballSpawn()
    {
        print("spawn pin");
        yield return new WaitForSeconds(1f);
        while(true)
        {
            
            pinballSpawner();
           
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void StartPinBallSpawner()
    {
        StartCoroutine("pinballSpawn");
    }
    public void StopPinBallSpawner()
    {
        StopCoroutine("pinballSpawn");
    }
}
