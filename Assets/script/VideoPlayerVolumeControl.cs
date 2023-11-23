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
        // VideoPlayer�̉����g���b�N���L���ł��邱�Ƃ��m�F
        if (videoPlayer.audioTrackCount > 0)
        {
            // ���ʂ��f�V�x���P�ʂŎ擾
            float volumeDB = 20.0f * Mathf.Log10(videoPlayer.GetDirectAudioVolume(0) * 10);

            if (volumeDB > thresholdVolume && !animationPlaying)
            {
                // ���ʂ�臒l�𒴂��A�A�j���[�V�������Đ�����Ă��Ȃ��ꍇ
                animator.SetTrigger("PlaySitAnimation");
                animationPlaying = true;
            }
            else if (volumeDB <= thresholdVolume && animationPlaying)
            {
                // ���ʂ�臒l�ȉ��ŁA�A�j���[�V�������Đ�����Ă���ꍇ
                animator.SetTrigger("ResetAnimation");
                animationPlaying = false;
            }
        }
    }
}

