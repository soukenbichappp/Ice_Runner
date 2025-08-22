using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject _bGMOnButton;
    [SerializeField] GameObject _bGMOffButton;
    [SerializeField] GameObject _effectOnButton;
    [SerializeField] GameObject _effectOffButton;

    private void Update()
    {
        //if(SoundManager.instance._bgmAudioSource.mute == true)
        //{
        //    _bGMOffButton.SetActive(false);
        //    _bGMOnButton.SetActive(true);
        //}
        //else if (SoundManager.instance._bgmAudioSource.mute == false)
        //{
        //    _bGMOffButton.SetActive(true);
        //    _bGMOnButton.SetActive(false);
        //}
        //
        //if(GameManager.instance.screenshakingeffect == true)
        //{
        //    _effectOnButton.SetActive(false);
        //    _effectOffButton.SetActive(true);
        //}
        //else if (GameManager.instance.screenshakingeffect == false)
        //{
        //    _effectOnButton.SetActive(true);
        //    _effectOffButton.SetActive(false);
        //}
    }

    public void SetBGMVolumeOn()
    {
        SoundManager.instance._bgmAudioSource.mute = false;
    }

    public void SetBGMVolumeOff()
    {
        SoundManager.instance._bgmAudioSource.mute = true;
    }
    public void SetEffectOn()
    {
        GameManager.instance.screenshakingeffect = true;
    }

    public void SetEffectOff()
    {
        GameManager.instance.screenshakingeffect = false;
    }


}
