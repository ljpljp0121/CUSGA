using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public int BGM;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        // �����Ƶ���Ž�����ļ�����  
        videoPlayer.loopPointReached += OnVideoEnded;

        videoPlayer.Play();
    }

    // ����Ƶ���Ž���ʱ���õķ���  
    private void OnVideoEnded(VideoPlayer vp)
    {
        Debug.Log("��Ƶ���Ž�����");
        Player.instance.canMove = true;
        SoundManager.instance.PlayBGM(BGM);
        Destroy(gameObject);
    }
}
