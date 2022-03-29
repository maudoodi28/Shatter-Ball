using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBallScript : MonoBehaviour
{
    public static int PinScore;
    public static int PinX;
    int a = 0;
    public static int PDestroy=0;
    // Start is called before the first frame update
    void Start()
    {
        //print("pin");
       // print(PinX);
      //  print(PDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
        a = PinScore;
        if(a==PinX && PDestroy==1)
        {
            PDestroy = 0;
            PinBallSpawner.DestroyS += 15;
            PinBallSpawner.DestroyBall = 1;
            Destroy(gameObject);
            //print(PinX);
            //print(a);
        }
    }
}
