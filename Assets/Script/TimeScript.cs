using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public static TimeScript TimeInstance;
    public static TimeScript XTimeInstance;
    public GameObject TextDisplay;
    public static int XMainTimer;
    public static int TimeBonus=15;
    public int MainTimer;
    int CountTimer;
    int Count = -1;
    public int StopTime;
    public bool takingAway = true;
    public int Pause = 0;
    public static int TimePause=0;
    public int XTime = 2;
    int xx = 15;

    void Awake()
    {
        TimeInstance = this;
        XTimeInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        print(xx);
        //TextDisplay.GetComponent<Text>().text = MainTimer + "s";
        TextDisplay.SetActive(false);

        // print(Pause);
        //print(CountTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.XPause==xx)
        {
            takingAway = false;
            //print("xpause");
            xx += 15;
        }
        if(takingAway== false && MainTimer > -1)
        {
            PrintTime();
            StartCoroutine(TimeTaking());
            
            //print("takingAway");
        }
    }
    IEnumerator TimeTaking()
    {
        
        takingAway = true;
        yield return new WaitForSeconds(1f);
        if(Pause==0)
        {
            TextDisplay.SetActive(true);
            //print(Pause);
            MainTimer -=1;
            //print(MainTimer);
            
            TextDisplay.GetComponent<Text>().text = MainTimer + "s";
            
            CountTimer = MainTimer;
            Count = CountTimer;
            TimeBonus = CountTimer;
            BallSpawner.SpeedSpawner = Count;
            MBallSpawner.SpeedSpawner = Count;
            RedBallScript.RSpeedTime = Count;
            GoldBallScript.GSpeedTime = Count;
            WhiteBallScript.WSpeedTime = Count;
            BombScript.BSpeedTime = Count;
            BoundaryScript.DestroyTimer=Count;
            takingAway = false;
            if (CountTimer == 0)
            {
                takingAway = true;
                TimeBonus = 15;
                TextDisplay.SetActive(false);
                //BoundaryScript.DestroyTimer = -1;
            }

        }
    }
    void PrintTime()
    {
        if (CountTimer == 0)
        {

            TextDisplay.SetActive(false);
            MainTimer = XMainTimer;
            takingAway = true;
            //print(takingAway);
           //print("mainTimer");
           // print(MainTimer);

        }
    }
    public void PauseTime()
    {
        Pause = 0;

    }
    public void ResumeTime()
    {
        takingAway = false;
        Pause = 0;
    }
    public void TimeAway()
    {
        takingAway = false;
    }
}
