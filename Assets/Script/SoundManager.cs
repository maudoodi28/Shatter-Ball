using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip RightBall, WrongBall, BombBall,BonusBall, WinningMoment;
    static AudioSource audioSrc;
    public static bool SoundX;
    public AudioSource ADsource;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        RightBall = Resources.Load<AudioClip>("rightBall");
        WrongBall = Resources.Load<AudioClip>("wrongBall");
        BombBall = Resources.Load<AudioClip>("bombBall");
        BonusBall = Resources.Load<AudioClip>("bonusBall");
        WinningMoment = Resources.Load<AudioClip>("winningMoment");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SoundX==true)
        {
            audioSrc.mute = true;
        }
        else
        {
            audioSrc.mute = false;
        }
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "rightBall":
                audioSrc.PlayOneShot(RightBall);
                break;
            case "wrongBall":
                audioSrc.PlayOneShot(WrongBall);
                break;
            case "bombBall":
                audioSrc.PlayOneShot(BombBall);
                break;
            case "bonusBall":
                audioSrc.PlayOneShot(BonusBall);
                break;
            case "winningMoment":
                audioSrc.PlayOneShot(WinningMoment);
                break;
        }
    }
}
