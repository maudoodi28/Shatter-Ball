using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyLogoScript : MonoBehaviour
{
    public static int OffLogo;
    public GameObject Soundmanager;
    public GameObject CompanyLogoPanel;
    public int SecondTime = 6;
    public int CountTime;
    public bool takingAway = false;
    int x = 0;


    void Awake()
    {
        if(OffLogo!=1)
        {
            CompanyLogoPanel.SetActive(true);
        }
        else
        {
            CompanyLogoPanel.SetActive(false);
            x = 1;
            Soundmanager.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (takingAway == false && SecondTime > 0 && x==0)
        {
            StartCoroutine(TimeTake());
            PrintTime();
        }
    }
    IEnumerator TimeTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1f);
        SecondTime -= 1;
        takingAway = false;
    }
    void PrintTime()
    {
        print(SecondTime);
        CountTime = SecondTime;
        if (CountTime == 1)
        {
            CompanyLogoPanel.SetActive(false);
            //AdmobAds.instance.reqBannerAd();
            MenuScene.OnMenu = 1;
            Soundmanager.SetActive(true);
            x = 1;
        }
    }
    
}
