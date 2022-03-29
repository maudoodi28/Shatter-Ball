using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBallScript : MonoBehaviour
{
    int speed = 7;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
        if (SoundManager.SoundX == false)
        {
            SoundManager.PlaySound("bonusBall");
        }

        GameManager.SPlifeInstance.SpecialLife();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
