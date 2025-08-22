using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource _bgmAudioSource;
    [SerializeField] AudioClip[] _audioClips;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 配列で取得したBGMの番号を受け取って再生する
    /// </summary>
    /// <param name="BGMNumber"></param>
    public void SetBGM(int BGMNumber)
    {
        _bgmAudioSource.clip = _audioClips[BGMNumber - 1];
        _bgmAudioSource.Play();
    }
}
