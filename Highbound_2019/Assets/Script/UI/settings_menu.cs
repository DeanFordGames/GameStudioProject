using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settings_menu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void SetVolume(float gameVolume)
    {
        mainMixer.SetFloat("gameVolume", gameVolume);
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
