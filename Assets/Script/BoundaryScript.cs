using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    public static int BdBall;
    public static int DestroyTimer=-1;
    int xx = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DestroyTimer>=0 && DestroyTimer<=5)
        {
            xx = 1;
            if(DestroyTimer==0)
            {
                DestroyTimer = -1;
            }
        }
        else
        {
            xx = 0;
        }
        //print(xx);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "White" && BdBall==0 && UiManager.Pausebutton == 0)
        {
            //print(xx);
            if(xx==0)
            {
                SoundManager.PlaySound("wrongBall");
                GameManager.LifeInstance.Lifepanel();

            }
        }
        if (collider.gameObject.tag == "Gold" && BdBall==1 && UiManager.Pausebutton == 0)
        {
            //print(xx);
            if (xx == 0)
            {
                SoundManager.PlaySound("wrongBall");
                GameManager.LifeInstance.Lifepanel();
            }
        }
        if (collider.gameObject.tag == "Red" && BdBall==2 && UiManager.Pausebutton == 0)
        {
            //print(xx);
            if (xx == 0)
            {
                SoundManager.PlaySound("wrongBall");
                GameManager.LifeInstance.Lifepanel();
            }
        }
        if (collider.gameObject.tag == "Bomb")
        {
            //print("Bomb");
            //GameManager.LifeInstance.Lifepanel();
        }
    }
}
