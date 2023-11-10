using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioWaveformAnalyzer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public LineRenderer lineRenderer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();

        // VideoPlayerの設定
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // LineRendererの設定
        lineRenderer.positionCount = audioSource.clip.samples;
    }

    void Update()
    {
        float[] samples = new float[audioSource.clip.samples];
        audioSource.clip.GetData(samples, 0);

        for (int i = 0; i < samples.Length; i++)
        {
            float x = (float)i / samples.Length;
            float y = samples[i]; // 波形データの値をy座標に使用
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}

