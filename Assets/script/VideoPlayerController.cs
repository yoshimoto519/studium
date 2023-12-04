using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private bool isPaused = false;

    void Start()
    {
        // VideoPlayer�̏����ݒ�Ȃǂ��s���ꍇ�͂����ɒǉ�
        videoPlayer.playOnAwake = false; // �ŏ��͎����Đ����Ȃ��悤�ɐݒ�
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Enter�L�[�������ꂽ�瓮����Đ�
            PlayVideo();
        }

        if (Input.GetMouseButtonDown(0))
        {
            // ���N���b�N�������ꂽ��ꎞ��~�܂��͍Đ���؂�ւ�
            TogglePause();
        }
    }

    void PlayVideo()
    {
        // ������Đ�����O�ɕK�v�Ȑݒ�Ȃǂ�����΂����ɒǉ�
        videoPlayer.Play();
    }

    void TogglePause()
    {
        if (videoPlayer.isPlaying)
        {
            // ���悪�Đ����Ȃ�ꎞ��~
            videoPlayer.Pause();
            isPaused = true;
        }
        else if (isPaused)
        {
            // �ꎞ��~���Ȃ�Đ��ĊJ
            videoPlayer.Play();
            isPaused = false;
        }
    }
}


