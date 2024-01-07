using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    public AudioSource BackgroundAudio;
    public AudioSource OnceAudio;
    [NonSerialized] public List<AudioClip> AudioClips = new List<AudioClip>();

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        BackgroundAudio.loop = true;

        for (int i = 0; i < Enum.GetNames(typeof(SoundType)).Length; i++) // hoac set dk: i < ConfigController.Sound.SoundDatas.Count
        {
            SoundData soundData = ConfigController.SoundConfig.SoundDatas.Find(item => item.SoundType == (SoundType)i);
            AudioClips.Add(soundData.Clip);
        }
    }

    public void PlayOnce(SoundType soundType)
    {
        AudioClip clip = AudioClips[(int)soundType];

        if (!clip || !Data.SoundState) return;

        OnceAudio.PlayOneShot(clip);
    }

    public void PlayBackground(SoundType soundType)
    {
        AudioClip clip = AudioClips[(int)soundType];

        if (!clip || !Data.MusicState) return;

        BackgroundAudio.clip = clip;
        BackgroundAudio.Play();
    }

    public void PauseBackground()
    {
        if (BackgroundAudio)
        {
            BackgroundAudio.Pause();
        }
    }

    public AudioSource PlayLoop(SoundType soundType)
    {
        AudioClip clip = AudioClips[(int)soundType];

        if (!clip || !Data.SoundState) return null;

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.Play();

        return audioSource;
    }

    public void StopAudio(SoundType soundType)
    {
        AudioClip clip = AudioClips[(int)soundType];

        //if (!clip || !Data.MusicState) return;

        OnceAudio.clip = clip;
        OnceAudio.Stop();
    }
}