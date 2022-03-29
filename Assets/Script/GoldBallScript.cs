using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBallScript : MonoBehaviour
{
    public static int GSpeedTime = -1;
    
    int gold = 1;
    float PerTenPspeed = 4f;
    public static float speed;
    float boostSpeed = 7f;
    int Point;
    int PointX = 10;


    // Start is called before the first frame update
    void Start()
    {
        
        Point = 10;
        PerTenPspeed = 4f;
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Point == GameManager.PerTenPointSpeed)
        {
           // print(Point);
            PerTenPspeed += 0.5f;
            speed = PerTenPspeed;
           // print(PerTenPspeed);
            Point = Point + PointX;
        }*/
        if (GSpeedTime >= 0 && GSpeedTime <= 5)
        {
            if (speed == boostSpeed)
            {
                boostSpeed += 1;
                speed = boostSpeed;
            }
            else
            {
                speed = boostSpeed;
            }
            if (GSpeedTime == 0)
            {
                GSpeedTime = -1;
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
        if (PinBallSpawner.ScoreBall == gold)
        {
            SoundManager.PlaySound("rightBall");
            GameManager.ScoreInstance.ScorePanel();
        }
        else if (TimeScript.TimeBonus != 15)
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
