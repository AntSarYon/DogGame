using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISettingsController : MonoBehaviour
{
    [SerializeField] private AudioMixer sfxMixer;
    [SerializeField] private AudioMixer bgMusicMixer;

    //-------------------------------------------------------

    public void SetSFXVolume(float volume)
    {
        sfxMixer.SetFloat("SFXVolume", volume);
    }

    public void SetBGMusicVolume(float volume)
    {
        bgMusicMixer.SetFloat("BGMusicVolume", volume);
    }
}
