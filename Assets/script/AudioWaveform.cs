using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioWaveform : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public LineRenderer waveformRenderer;
    public int resolution = 1024
        ;

    private float[] audioWaveform;

    void Start()
    {
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);

        audioWaveform = new float[resolution];
        waveformRenderer.positionCount = resolution;
    }

    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            audioSource.GetOutputData(audioWaveform, 0);
            UpdateWaveform();
        }
    }

    void UpdateWaveform()
    {
        for (int i = 0; i < resolution; i++)
        {
            float x = (float)((float)i / resolution * videoPlayer.time);
            float y = audioWaveform[i];
            waveformRenderer.SetPosition(i, new Vector3(x, y, 0f));
        }
    }
}

