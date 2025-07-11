using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public void SetBGMVolume(float volume)
    {
        SoundManager.instance.SetBGMVolume(volume);
    }
}
