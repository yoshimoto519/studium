using UnityEngine;
using UnityEngine.Video;

public class VideoCnt : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public KeyCode playKey = KeyCode.S;      // 動画再生に使用するキー
    public KeyCode skipKey = KeyCode.Space;  // 30秒スキップに使用するキー
    public KeyCode pauseKey = KeyCode.Return;
    //public KeyCode stopKey = KeyCode.T;// 一時停止に使用するキー
    public float skipDuration = 30f;         // スキップする秒数

    private void Start()
    {
        // VideoPlayerの初期設定などを行う場合はここに追加
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer not assigned!");
            return;
        }

        // スキップ可能な状態に遷移するためのリスナーを登録
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void Update()
    {
        if (Input.GetKeyDown(playKey))
        {
            PlayVideo();
        }

        if (Input.GetKeyDown(skipKey))
        {
            SkipVideo();
        }
        if (Input.GetKeyDown(pauseKey))
        {
            PauseVideo();
        }
    }

    private void PlayVideo()
    {
        // 動画が再生中でなければ再生
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }

    private void SkipVideo()
    {
        // 動画が再生中であればスキップ
        if (videoPlayer.isPlaying)
        {
            // 動画の再生位置にスキップする秒数を加算
            videoPlayer.time += skipDuration;
        }
    }

    
    private void PauseVideo()
    {
        // 動画が再生中なら一時停止または再生を切り替え
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }

    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // 動画が終了したときの処理（ここで何かしらの終了処理を行う）
        Debug.Log("Video End");
    }
}
