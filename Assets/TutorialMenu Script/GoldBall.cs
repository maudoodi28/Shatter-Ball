using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBall : MonoBehaviour
{
    public static GoldBall DestroyInstance;
    void Awake()
    {
        DestroyInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 7f);
        transform.Translate(Vector3.down * 5 * Time.deltaTime);
    }
    public void BallDestroy()
    {
        Destroy(gameObject);
    }

}
