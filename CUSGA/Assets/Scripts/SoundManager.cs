using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;
    public List<AudioClip> BgmList;
    public List<AudioClip> SoundList;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayBGM(0);
    }


    public void PlayBGM(int i, float volume = 0.8f)
    {
        audioSource.Stop();
        audioSource.clip = BgmList[i];
        audioSource.volume = volume;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void PlayerSound(int i, float volume = 1.0f)
    {
        audioSource.PlayOneShot(SoundList[i], volume);
    }

    public void PlaySound(AudioSource audioSource,int i, float volume = 1f)
    {
        audioSource.PlayOneShot(SoundList[i], volume);
    }
}
