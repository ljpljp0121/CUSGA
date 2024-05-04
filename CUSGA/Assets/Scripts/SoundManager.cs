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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="volume"></param>
    public void PlayerSound(int i, float volume = 1.0f)
    {
        audioSource.PlayOneShot(SoundList[i], volume);
    }
}
