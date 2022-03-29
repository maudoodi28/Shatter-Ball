using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text HighestScore;
    public Text scoreText;
    public Text GOscore;
    public int score=0;
    public static GameManager ScoreInstance;
    public static GameManager LifeInstance;
    public static GameManager SPlifeInstance;
    public static GameManager SpawnerInstance;
    public static GameManager instanceRewarded;
    public static GameManager instanceWinLife;
    public static GameManager instanceForGOpanel;
    public GameObject LifePanel;
    public GameObject WinLifePanel;
    public int lives = 3;
    int Xlives;
    public static int XPause;
    public static int MaxScore;
    public static int Specialscore;
    public static int PerTenPointSpeed;
    int PerTen = 10;
    int xx=15;
    int giftLife = 0;
    public static int wPanel = 0;
    public int Winlife;
   // int SpecialScore = 7;
    int ss;
    int HScore;
    int WatchingVideo = 0;
    public int LifeFromVideo = 1;
    float ballSpeed = 4;
    // Start is called before the first frame update
    void Awake()
    {
        instanceForGOpanel = this;
        SPlifeInstance = this;
        ScoreInstance = this;
        LifeInstance = this;
        SpawnerInstance = this;
        instanceRewarded = this;
        instanceWinLife = this;
    }
    void Start()
    {
        //PerTen = 10;
        Winlife = 0;
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            WatchingVideo = 1;
            print("Network Available");
        }
        else
        {
            WatchingVideo = 2;
            print("Network not Available");
        }
        
        HighestScore.text = PlayerPrefs.GetInt("ScoreHigh", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(PerTenPointSpeed==PerTen)
        {
            ballSpeed += 0.5f;
            WhiteBallScript.speed = ballSpeed;
            RedBallScript.speed = ballSpeed;
            GoldBallScript.speed = ballSpeed;
            BombScript.speed = ballSpeed;
            //RedBallScript.RspeedInstance.SpeedUp();
            print("perfect");
            PerTen += 10;
        }
        else
        {
            WhiteBallScript.speed = ballSpeed;
            RedBallScript.speed = ballSpeed;
            GoldBallScript.speed = ballSpeed;
            BombScript.speed = ballSpeed;
        }
        if(LifeFromVideo==2)
        {
            WinLife();
            LifeFromVideo = 1;
        }
        highestscore();
        if (XPause==xx)
        {
            //TimeScript.TimeInstance.takingAway = false;
            TimeScript.XMainTimer = 6;
            xx = xx + 15;
        }
    }
    public void ScorePanel()
    {
        score++;
        ss = score;
        
        PerTenPointSpeed = score;
        HScore = score;
        XPause = score;
        MaxScore = score;
        Specialscore = score;
        PinBallScript.PinScore = score;
        PinBallSpawner.SpScore = score;
    // print(score);
        scoreText.text = score.ToString();
        GOscore.text = score.ToString();
        //RedBallScript.RspeedInstance.SpeedUp();
    }
    public void Lifepanel()
    {
        if(lives>0)
        {
            //print(lives);
            lives--;
            //print(lives);
            LifePanel.transform.GetChild(lives).gameObject.SetActive(false);
            
            //print("life minus");
        }
        if(lives<=0)
        {
            //AdmobAds.instance.ShowInterstitialAd();
            if(WatchingVideo==1)
            {
                WatchVideo();
                Winlife = 0;
                //WatchingVideo = 0;
            }
            
            else
            {
                UiManager.GOpanelInstance.GameoverPanel();
            }
            
        }
    }
    public void SpecialLife()
    {
        if(lives<3 && lives>0)
        {
            //print("Special"+lives);
            lives += 1;
            //print(lives);
            LifePanel.transform.GetChild(lives-1).gameObject.SetActive(true);
        }
    }
    public void highestscore()
    {
        if (HScore > PlayerPrefs.GetInt("ScoreHigh", 0))
        {
            PlayerPrefs.SetInt("ScoreHigh", HScore);
            HighestScore.text = PlayerPrefs.GetInt("ScoreHigh").ToString();
        }
    }
    public void WinLife()
    {
        //int x = 0;
        if(UiManager.SeeAfterRvideo==1)
        {
            
            wPanel = 0;
            print("winlife");
            giftLife += 1;
            Xlives = 0;
            lives++;
            //Xlives += 1;
            print(lives);
            LifePanel.transform.GetChild(Xlives).gameObject.SetActive(true);
            //AdmobAds.Instance.Xwin = 5;
            UiManager.SeeAfterRvideo = 0;
            //Xlives = 0;
            Winlife = 1;
            BallSpawner.RSPInstance.StartSpawningBall();
            MBallSpawner.MSPInstance.StartSpawningBall();
            LBallSpawner.LSPInstance.StartSpawningBall();
        }
        
        
    }
    public void WatchVideo()
    {
         WinLifePanel.SetActive(true);
         wPanel = 1;
         BallSpawner.RSPInstance.StopSpawningBall();
         MBallSpawner.MSPInstance.StopSpawningBall();
         LBallSpawner.LSPInstance.StopSpawningBall();
    }
}
