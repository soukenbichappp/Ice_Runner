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
        if(SoundManager.instance._bgmAudioSource.mute == false)
        {
            _bGMOnButton.SetActive(true);
            _bGMOffButton.SetActive(false);
        }
        else if (SoundManager.instance._bgmAudioSource.mute == true)
        {
            _bGMOnButton.SetActive(false);
            _bGMOffButton.SetActive(true);
        }
        
        if(GameManager.instance.screenShakingEffect == true)
        {
            _effectOnButton.SetActive(true);
            _effectOffButton.SetActive(false);
        }
        else if (GameManager.instance.screenShakingEffect == false)
        {
            _effectOnButton.SetActive(false);
            _effectOffButton.SetActive(true);
        }
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
        GameManager.instance.screenShakingEffect = true;
    }

    public void SetEffectOff()
    {
        GameManager.instance.screenShakingEffect = false;
    }


}
