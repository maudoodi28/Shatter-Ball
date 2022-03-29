using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundManager : MonoBehaviour
{
    public AudioSource ADsource;
    public static bool GameBGsound;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameBGsound==true)
        {
            ADsource.mute = true;
        }
        else
        {
            ADsource.mute = false;
        }
    }
}
