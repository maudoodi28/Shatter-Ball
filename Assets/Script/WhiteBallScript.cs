using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallScript : MonoBehaviour
{
    
    public static int WSpeedTime = -1;
    int white = 0;
    float PerTenPspeed = 4f;
    float boostSpeed = 7f;
    public static float speed;
    int Point = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Point = 10;
        PerTenPspeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(GameManager.PerTenPointSpeed==Point)
        {
            PerTenPspeed += 0.5f;
            speed = PerTenPspeed;
           // print(PerTenPspeed);
            Point += 10;
        }*/
        if (WSpeedTime >= 0 && WSpeedTime <= 5)
        {
            if(speed==boostSpeed)
            {
                boostSpeed += 1;
                speed = boostSpeed;
            }
            else
            {
                speed = boostSpeed;
            }
            if (WSpeedTime == 0)
            {
                WSpeedTime = -1;
            }
        }
        /*else
        {
            speed = PerTenPspeed;
        }*/
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
        if (PinBallSpawner.ScoreBall == white)
        {
            SoundManager.PlaySound("rightBall");
            GameManager.ScoreInstance.ScorePanel();
        }
        else if(TimeScript.TimeBonus!=15)
        {
            SoundManager.PlaySound("rightBall");
            GameManager.ScoreInstance.ScorePanel();
        }
        else
        {
            SoundManager.PlaySound("wrongBall");
            GameManager.LifeInstance.Lifepanel();
        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
