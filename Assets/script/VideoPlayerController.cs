using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private bool isPaused = false;

    void Start()
    {
        // VideoPlayerの初期設定などを行う場合はここに追加
        videoPlayer.playOnAwake = false; // 最初は自動再生しないように設定
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Enterキーが押されたら動画を再生
            PlayVideo();
        }

        if (Input.GetMouseButtonDown(0))
        {
            // 左クリックが押されたら一時停止または再生を切り替え
            TogglePause();
        }
    }

    void PlayVideo()
    {
        // 動画を再生する前に必要な設定などがあればここに追加
        videoPlayer.Play();
    }

    void TogglePause()
    {
        if (videoPlayer.isPlaying)
        {
            // 動画が再生中なら一時停止
            videoPlayer.Pause();
            isPaused = true;
        }
        else if (isPaused)
        {
            // 一時停止中なら再生再開
            videoPlayer.Play();
            isPaused = false;
        }
    }
}


