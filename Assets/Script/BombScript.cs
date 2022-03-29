using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public static int BSpeedTime = -1;

    float PerTenPspeed = 4f;
    public static float speed;
    float boostSpeed = 7f;
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
        /*if (GameManager.PerTenPointSpeed == Point)
        {
            PerTenPspeed += 0.5f;
            speed = PerTenPspeed;
            Point += 10;
        }*/
        if (BSpeedTime >= 0 && BSpeedTime <= 5)
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
            if (BSpeedTime == 0)
            {
                BSpeedTime = -1;
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
        if (TimeScript.TimeBonus == 15)
        {
            SoundManager.PlaySound("bombBall");
            GameManager.LifeInstance.Lifepanel();
        }
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
