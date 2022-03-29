using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBSpawner : MonoBehaviour
{
    public GameObject[] SPballs;
    public static SpecialBSpawner SPInstance;

    // Start is called before the first frame update
    void Start()
    {
        SPInstance = this;
        //print("SpecialBall");
        //StartSpawningBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpecialSpawner()
    {
        int SPrand = Random.Range(0, SPballs.Length);
        float randomSP = Random.Range(5.13f, 7.65f);
        Vector3 RandomPosSP = new Vector3(transform.position.x, randomSP, transform.position.y);
        Instantiate(SPballs[SPrand], RandomPosSP, transform.rotation);
        print("SpecialBall");
    }
    IEnumerator ballSpawn()
    {
        yield return new WaitForSeconds(.1f);
        while (true)
        {
            SpecialSpawner();
            yield return new WaitForSeconds(2f);
        }
    }
    public void StartSpawningBall()
    {
        StartCoroutine(ballSpawn());
    }
    public void StopSpawningBall()
    {
        StopCoroutine(ballSpawn());
    }
}
