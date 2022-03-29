using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
   
    public static UiManager UiInstance;
    public static UiManager GOpanelInstance;
    public static UiManager AfterClickVideo;
    //public static UiManager WatchInstance;
    public GameObject PinBSpawner;
    public GameObject PauseMenuPanel;
    public GameObject WinLifePanel;
    public GameObject GameOverPanel;
    public static int Pausebutton = 0;
    int winLife;
    int AfterWpanel;
    public static int SeeAfterRvideo=0;
    // Start is called before the first frame update
    void Start()
    {
        SeeAfterRvideo = 0;
        AfterWpanel = 0;
        GOpanelInstance = this;
        UiInstance = this;
        AdmobAds.instance.requestInterstital();
        AdmobAds.instance.loadRewardVideo();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void PauseButton()
    {
        if(GameManager.wPanel != 1)
        {
            PauseMenuPanel.SetActive(true);
            PinBSpawner.SetActive(false);
            BallSpawner.RSPInstance.StopSpawningBall();
            MBallSpawner.MSPInstance.StopSpawningBall();
            LBallSpawner.LSPInstance.StopSpawningBall();
            Pausebutton = 1;
        }
        
    }
    public void ResumeButton()
    {
        PauseMenuPanel.SetActive(false);
        PinBSpawner.SetActive(false);
        BallSpawner.RSPInstance.StartSpawningBall();
        MBallSpawner.MSPInstance.StartSpawningBall();
        LBallSpawner.LSPInstance.StartSpawningBall();
        Pausebutton = 0;
    }
    public void RestartButton()
    {
        GameManager.wPanel = 0;
        SceneManager.LoadScene("Game");
        AdmobAds.instance.reqBannerAd();

    }
    public void BackToMenu()
    {
        GameManager.wPanel = 0;
        AdmobAds.instance.ShowInterstitialAd();
        SceneManager.LoadScene("Menu");
        AdmobAds.instance.reqBannerAd();
        CompanyLogoScript.OffLogo = 1;
    }
    public void ResumeMenuExit()
    {
        GameManager.wPanel = 0;
        Application.Quit();
    }
    public void GameoverPanel()
    {
        GameManager.wPanel = 1;
        GameOverPanel.SetActive(true);
        SoundManager.PlaySound("winningMoment");
        BallSpawner.RSPInstance.StopSpawningBall();
        MBallSpawner.MSPInstance.StopSpawningBall();
        LBallSpawner.LSPInstance.StopSpawningBall();
    }
    public void WLPanelCross()
    {
        WinLifePanel.SetActive(false);
        AdmobAds.instance.ShowInterstitialAd();
        GameoverPanel();
    }
    public void WLPanelVideo()
    {
        
        SeeAfterRvideo = 1;
        AfterWpanel = 1;
        winLife = 1;
        WinLifePanel.SetActive(false);
        AdmobAds.instance.showVideoAd();
        AfterWatchVideo();
        //GameManager.instanceWinLife.WinLife();
        //GameOverPanel.SetActive(true);
    }
    public void AfterWatchVideo()
    {
        if (AfterWpanel == 1 && GameManager.instanceForGOpanel.Winlife == 0 && AdmobAds.instance.Xwin == 5)
        {
            print("GameOver");
            GameoverPanel();
            AfterWpanel = 0;
            GameManager.instanceForGOpanel.Winlife = 0 ;
            AdmobAds.instance.Xwin = 5;
            //AdmobAds.WinInstance.Xwin = 8;
        }
    }
    
}
