using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private global Global;

    public void OnValueChange(float value)
    {
        mixer.SetFloat("music", value);
        Global.volume = value;
    }
}
