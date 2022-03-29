using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour
{
    public Text ScoreHighest;
    public int Mscore;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        ScoreHighest.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        print(Mscore);
    }

    // Update is called once per frame
    void Update()
    {
        highestscore();
        Mscore = GameManager.MaxScore;
    }
    public void highestscore()
    {
        if (Mscore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", Mscore);
            ScoreHighest.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
}
