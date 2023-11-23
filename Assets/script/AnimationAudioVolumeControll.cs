using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnimationAudioVolumeControll : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public Animator animator;
    public float thresholdVolume = 80.0f;
    private bool animationPlaying = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);


    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            // 音量をデシベル単位で取得
            float volumeDB = 20.0f * Mathf.Log10(audioSource.volume * 10);

            if (volumeDB > thresholdVolume )
            {
                animationPlaying = true;
            }
            else if (volumeDB <= thresholdVolume)
            {
                animationPlaying = false;
            }
        }
    }
}
