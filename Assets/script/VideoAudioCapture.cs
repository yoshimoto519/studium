using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoAudioCapture : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();

        // VideoPlayer�̐ݒ�
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);

        // AudioSource�ɉ�����ݒ�
        audioSource.clip = videoPlayer.GetTargetAudioSource(0).clip;
    }
}
