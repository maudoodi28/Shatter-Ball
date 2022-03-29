using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfxOnOffScript : MonoBehaviour
{
    [SerializeField] Image SFXOnIcon;
    [SerializeField] Image SFXOffIcon;
    private bool muted1 = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted1"))
        {
            PlayerPrefs.SetInt("muted1", 0);
            LoadSFX();
        }
        else
        {
            LoadSFX();
        }
        UpdateButtonIcon();
        SoundManager.SoundX = muted1;
        print(SoundManager.SoundX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonPress()
    {
        if(muted1==false)
        {
            muted1 = true;
            SoundManager.SoundX = true;
            print(SoundManager.SoundX);
        }
        else
        {
            muted1 = false;
            SoundManager.SoundX = false;
            print(SoundManager.SoundX);
        }
        SaveSFX();
        UpdateButtonIcon();
    }

    public void UpdateButtonIcon()
    {
        if(muted1==false)
        {
            SFXOnIcon.enabled = true;
            SFXOffIcon.enabled = false;
        }
        else
        {
            SFXOnIcon.enabled = false;
            SFXOffIcon.enabled = true;
        }
    }

    public void LoadSFX()
    {
        muted1 = PlayerPrefs.GetInt("muted1") == 1;
    }
    public void SaveSFX()
    {
        PlayerPrefs.SetInt("muted1", muted1 ? 1 : 0);
    }
}
