using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager LifePlusInstance;
    public static TutorialManager LifeMinusInstance;
    public static TutorialManager ScoreInstance;
    public int score = 0;
    public Text ScoreText;
    public GameObject LifePanel;
    int lives = 3;
    void Awake()
    {
        ScoreInstance = this;
        LifePlusInstance = this;
        LifeMinusInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scorepanel()
    {
        score++;
        ScoreText.text = score.ToString();
    }
    public void lifePanel()
    {
        lives--;
        LifePanel.transform.GetChild(lives).gameObject.SetActive(false);
    }
    public void specialLife()
    {
        lives++;
        LifePanel.transform.GetChild(lives-1).gameObject.SetActive(true);
    }
}
