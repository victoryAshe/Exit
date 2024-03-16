using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioCtrl : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider bgmSlider;
    public Slider sfxSlider;

    string bgmGroupName = "BackGround";
    string sfxGroupName = "SFX";

    public AudioSource sfxSource;
    public AudioSource bgmSource;
    public AudioClip buttonClip;
    public AudioClip mainBgmClip;
    public AudioClip subBgmClip;
    public bool hasInitedSetting = false;

    WaitForSeconds wfs = new WaitForSeconds(0.01f);

    public static AudioCtrl instance;

    private void Start()
    {
        if (instance == null) instance = this;
    }

    public void InitSetting()
    {
        float tempVolume;
        masterMixer.GetFloat(bgmGroupName, out tempVolume);
        bgmSlider.value = tempVolume;
        bgmSlider.onValueChanged.AddListener(BGMControl);

        masterMixer.GetFloat(sfxGroupName, out tempVolume);
        sfxSlider.value = tempVolume;
        sfxSlider.onValueChanged.AddListener(SFXControl);
    }

    public void BGMControl(float value)
    {
        if (value == -40f) masterMixer.SetFloat(bgmGroupName, -80);
        else masterMixer.SetFloat(bgmGroupName, value);
    }

    public void SFXControl(float value)
    {
        if (value == -40f) masterMixer.SetFloat(sfxGroupName, -80);
        else masterMixer.SetFloat(sfxGroupName, value);
    }


    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClip, 1.0f);
    }

    public IEnumerator PlayBgm(Enums.bgmType type)
    {
        float originVolume;
        masterMixer.GetFloat(bgmGroupName, out originVolume);

        float currVolume = originVolume;
        if (bgmSource.isPlaying)
        {
            while (originVolume > -80f)
            {
                currVolume -= 10f;
                masterMixer.SetFloat(bgmGroupName, currVolume);
                yield return wfs;
            }

            currVolume = -80f;
            masterMixer.SetFloat(bgmGroupName, currVolume);
            
        }

        
        if (type == Enums.bgmType.메인_및_인게임)
        {
            bgmSource.clip = mainBgmClip;
        }
        else if (type == Enums.bgmType.프롤로그_및_튜토리얼)
        {
            bgmSource.clip = subBgmClip;
        }

        while(currVolume < originVolume)
        {
            currVolume += 10f;
            masterMixer.SetFloat(bgmGroupName, currVolume);
            yield return wfs;
        }
        masterMixer.SetFloat(bgmGroupName, originVolume);
    }
}
