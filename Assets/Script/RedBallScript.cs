using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallScript : MonoBehaviour
{
    public static RedBallScript RspeedInstance;
    public static int RSpeedTime = -1;
    
    int red = 2;
    float PerTenPspeed = 4f;
    public static float speed;
    float boostSpeed = 7f;
    static int Point;

    void Awake()
    {
        RspeedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Point = 10;
        PerTenPspeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GameManager.PerTenPointSpeed == Point)
        {
            //PerTenPspeed += 0.5f;
            //speed = PerTenPspeed;
            print(speed);
            Point += 10;
        }*/
        if (RSpeedTime >= 0 && RSpeedTime <= 5)
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
            if (RSpeedTime == 0)
            {
                RSpeedTime = -1;
            }
        }
       /* else
        {
            speed = PerTenPspeed;
        }*/
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    /*public void SpeedUp()
    {
        
        PerTenPspeed += 0.5f;
        
        speed = PerTenPspeed;
        print(PerTenPspeed);
        print(speed);
    }*/
    void OnMouseDown()
    {
        Destroy(gameObject);
        if (PinBallSpawner.ScoreBall==red)
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
