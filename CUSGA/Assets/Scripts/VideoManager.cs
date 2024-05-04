using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        // 添加视频播放结束后的监听器  
        videoPlayer.loopPointReached += OnVideoEnded;

        videoPlayer.Play();
    }

    // 当视频播放结束时调用的方法  
    private void OnVideoEnded(VideoPlayer vp)
    {
        Debug.Log("视频播放结束！");
        Player.instance.canMove = true;
        SoundManager.instance.PlayBGM(0);
        Destroy(gameObject);
    }
}
