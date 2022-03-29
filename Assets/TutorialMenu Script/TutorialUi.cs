using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialUi : MonoBehaviour
{
    public
    bool isPaused = false;
    int PinX = 1;
    public GameObject PinBallArrow;
    public GameObject PinBallText;
    public GameObject GoldArrow;
    public GameObject GoldText;
    public GameObject RedArrow;
    public GameObject RedText;
    public GameObject SpecialArrow;
    public GameObject SpecialText;
    public GameObject BombArrow;
    public GameObject BombText;
    public GameObject BoostTime;
    public GameObject BoostTimeText;
    public GameObject BoostTimeArrow;

    public GameObject PlayButton;
    public GameObject continueButton;
    public GameObject Next;
    public GameObject Skip;
    public GameObject Pin;


    public static int BurstX = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void NextTutorial()
    {
        if (PinX == 1)
        {
            PinBallArrow.SetActive(false);
            PinBallText.SetActive(false);
            BallSpawner1.StartInstance.StartSpawningBall();
            BallSpawner2.StartInstance.StartSpawningBall();
            BallSpawner3.StartInstance.StartSpawningBall();
            PinX++;
        }
        if(BurstX==1)
        {
            TutorialManager.ScoreInstance.scorepanel();
            GoldArrow.SetActive(false);
            GoldText.SetActive(false);
            GoldBall.DestroyInstance.BallDestroy();
        }
        if(BurstX==2)
        {
            TutorialManager.LifeMinusInstance.lifePanel();
            RedArrow.SetActive(false);
            RedText.SetActive(false);
            RedBall.DestroyInstance.BallDestroy();
        }
        if(BurstX==3)
        {
            TutorialManager.LifePlusInstance.specialLife();
            SpecialArrow.SetActive(false);
            SpecialText.SetActive(false);
            SpecialBall.DestroyInstance.BallDestroy();
        }
        if(BurstX==4)
        {
            TutorialManager.LifeMinusInstance.lifePanel();
            BombArrow.SetActive(false);
            BombText.SetActive(false);
            BombBall.DestroyInstance.BallDestroy();
        }
        if (BurstX == 5)
        {
            TutorialManager.ScoreInstance.scorepanel();
            TutorialManager.ScoreInstance.scorepanel();
            GoldBall.DestroyInstance.BallDestroy();
            RedBall.DestroyInstance.BallDestroy();
            BoostTime.SetActive(false);
            BoostTimeText.SetActive(false);
            BoostTimeArrow.SetActive(false);
            LetPlay();
        }

        Time.timeScale = 1;
    }
    public void LetPlay()
    {
        BallSpawner1.StartInstance.StopSpawningBall();
        BallSpawner2.StartInstance.StopSpawningBall();
        BallSpawner3.StartInstance.StopSpawningBall();
        PlayButton.SetActive(true);
        continueButton.SetActive(true);
        Pin.SetActive(false);
        Next.SetActive(false);
        Skip.SetActive(false);
    }
    public void ContinueButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void SkipTutorial()
    {
        SceneManager.LoadScene("Game");
    }
}
