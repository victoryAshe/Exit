using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioCtrl : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider bgSoundSlider;
    public Slider sfxSoundSlider;

    public void BackAudioControl()
    {
        float sound = bgSoundSlider.value;

        if (sound == -40f) masterMixer.SetFloat("BackGround", -80);
        else masterMixer.SetFloat("BackGround", sound);
    }

    public void SFXAudioControl()
    {
        float sound = sfxSoundSlider.value;
        if (sound == -40f) masterMixer.SetFloat("SFX", -80);
        else masterMixer.SetFloat("SFX", sound);
    }
    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
