using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundMusicScript : MonoBehaviour
{
    public AudioSource AdSource;
    [SerializeField] Image MusicOnIcon;
    [SerializeField] Image MusicOffIcon;
    public static int SoundOffForLogo=0;
    int x = 0;
    private bool muted = false;
   // private static BackGroundMusicScript BGSound;

    // Start is called before the first frame update
    void Start()
    {
        AdSource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            LoadBG();
        }
        else
        {
            LoadBG();
        }
        UpdateButtonIcon();
        
        AdSource.mute = muted;
        BGSoundManager.GameBGsound = muted;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AdSource.mute = true;
            BGSoundManager.GameBGsound = true;
        }
        else
        {
            muted = false;
            AdSource.mute = false;
            BGSoundManager.GameBGsound = false;
        }
        SaveBG();
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            
            MusicOnIcon.enabled = true;
            MusicOffIcon.enabled = false;
        }
        else
        {
            
            MusicOnIcon.enabled = false;
            MusicOffIcon.enabled = true;
        }
    }
    private void LoadBG()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void SaveBG()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
