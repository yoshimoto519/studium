using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnimationSpectrumControll : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public AudioSource audioSource;
    public Animator animator;
    public float thresholdVolume = 80.0f;
    private bool animationPlaying = false;
    public int resolution = 1024;
    private float[] spectrumData;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);
        spectrumData = new float[resolution];
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Hamming);

        }
    }
}
