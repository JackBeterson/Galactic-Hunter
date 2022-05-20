using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioSliders : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetSounds (float volume)
    {
        audioMixer.SetFloat("sounds", volume);
    }
    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("music", volume);
    }
}
