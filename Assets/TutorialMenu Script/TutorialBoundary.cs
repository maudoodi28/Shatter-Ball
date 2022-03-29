using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBoundary : MonoBehaviour
{
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

    public static int SpawnX=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Gold" && SpawnX==1)
        {
            TutorialUi.BurstX = 1;
            
            GoldArrow.SetActive(true);
            GoldText.SetActive(true);
            Time.timeScale = 0;

        }
        if (collider.gameObject.tag == "Red" && SpawnX == 2)
        {
            TutorialUi.BurstX = 2;
            
            RedArrow.SetActive(true);
            RedText.SetActive(true);
            Time.timeScale = 0;

        }
        if (collider.gameObject.tag == "Special" && SpawnX == 3)
        {
            TutorialUi.BurstX = 3;
            
            SpecialArrow.SetActive(true);
            SpecialText.SetActive(true);
            Time.timeScale = 0;

        }
        if (collider.gameObject.tag == "Bomb" && SpawnX == 4)
        {
            TutorialUi.BurstX = 4;

            BombArrow.SetActive(true);
            BombText.SetActive(true);
            Time.timeScale = 0;

        }
        if (collider.gameObject.tag == "Bomb" && SpawnX == 5)
        {
            TutorialUi.BurstX = 5;

            BoostTime.SetActive(true);
            BoostTimeText.SetActive(true);
            BoostTimeArrow.SetActive(true);
            Time.timeScale = 0;

        }
    }
}
