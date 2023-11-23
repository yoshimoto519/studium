using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerVolumeControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Animator animator;
    public float thresholdVolume = 80.0f;

    private bool animationPlaying = false;

    void Update()
    {
        // VideoPlayerの音声トラックが有効であることを確認
        if (videoPlayer.audioTrackCount > 0)
        {
            // 音量をデシベル単位で取得
            float volumeDB = 20.0f * Mathf.Log10(videoPlayer.GetDirectAudioVolume(0) * 10);

            if (volumeDB > thresholdVolume && !animationPlaying)
            {
                // 音量が閾値を超え、アニメーションが再生されていない場合
                animator.SetTrigger("PlaySitAnimation");
                animationPlaying = true;
            }
            else if (volumeDB <= thresholdVolume && animationPlaying)
            {
                // 音量が閾値以下で、アニメーションが再生されている場合
                animator.SetTrigger("ResetAnimation");
                animationPlaying = false;
            }
        }
    }
}

