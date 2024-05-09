using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public int BGM;
    public GameObject nextVideoPlayer;
    public GameObject black;
    public bool isOver;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        videoPlayer.prepareCompleted += OnVideoPrepared;
        // 添加视频播放结束后的监听器  
        videoPlayer.loopPointReached += OnVideoEnded;

        videoPlayer.Play();
        Player.instance.canMove = false;
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        Invoke("Off", 0.3f);
    }

    private void Off()
    {
        if (black != null)
            black.SetActive(false);
    }

    // 当视频播放结束时调用的方法  
    private void OnVideoEnded(VideoPlayer vp)
    {
        black.SetActive(false);
        if (isOver)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        if (nextVideoPlayer != null)
        {
            nextVideoPlayer.SetActive(true);
            if (nextVideoPlayer.GetComponent<VideoPlayer>() != null)
            {
                black.SetActive(true);
            }
        }

        Player.instance.canMove = true;
        gameObject.SetActive(false);
        if(BGM == 99) { SoundManager.instance.audioSource.Stop(); return; }
        SoundManager.instance.PlayBGM(BGM);
    }
}
