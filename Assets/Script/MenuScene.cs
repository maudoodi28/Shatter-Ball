using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject MainBG;
    public GameObject OptionalBG;
    public GameObject MenuBG;
    public GameObject OtherBG;
    public GameObject MenuPanel;
    public GameObject HtoPPanel;
    public GameObject HighestScorePanel;
    public GameObject OptionPanel;
    public GameObject SoundPanel;
    public static int OnMenu=0;
    int x = 0;
    int SceneX;
    // Start is called before the first frame update
    void Start()
    {
        SceneX = PlayerPrefs.GetInt("ValueScene",0);
    }

    // Update is called once per frame
    void Update()
    {
        if(OnMenu==1 && x==0)
        {
            MenuPanel.SetActive(true);
            //AdmobAds.instance.reqBannerAd();
            x = 1;
        }
    }
    public void PlayButton()
    {
        if(SceneX==0)
        {
            PlayerPrefs.SetInt("ValueScene", 1);
            SceneManager.LoadScene("SceneTutorial");
            
        }
        else
        {
            SceneManager.LoadScene("Game");
            AdmobAds.instance.reqBannerAd();
        }
        
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
    
    public void OptionButton()
    {
        //AdmobAds.instance.hideBanner();
        MainBG.SetActive(false);
        OptionalBG.SetActive(true);
        OptionPanel.SetActive(true);
        MenuPanel.SetActive(false);
       // AdmobAds.instance.reqBannerAd();
    }
    public void OptionPanelBackButton()
    {
        MainBG.SetActive(true);
        OptionalBG.SetActive(false);
        OptionPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
    public void HowToPlayPanel()
    {
        HtoPPanel.SetActive(true);
        OptionPanel.SetActive(false);

    }
    public void HtoPBackButton()
    {
        HtoPPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }
    public void HighScorePanel()
    {
        HighestScorePanel.SetActive(true);
        OptionPanel.SetActive(false);
    }
    public void HSPanelBackButton()
    {
       // AdmobAds.instance.ShowInterstitialAd();
        HighestScorePanel.SetActive(false);
        OptionPanel.SetActive(true);
    }
    public void SoundBackButton()
    {
        //AdmobAds.instance.ShowInterstitialAd();
        SoundPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }
    public void Soundpanel()
    {
        OptionPanel.SetActive(false);
        SoundPanel.SetActive(true);
    }

}
