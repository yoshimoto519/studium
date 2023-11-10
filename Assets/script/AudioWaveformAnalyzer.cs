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

        // VideoPlayer�̐ݒ�
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // LineRenderer�̐ݒ�
        lineRenderer.positionCount = audioSource.clip.samples;
    }

    void Update()
    {
        float[] samples = new float[audioSource.clip.samples];
        audioSource.clip.GetData(samples, 0);

        for (int i = 0; i < samples.Length; i++)
        {
            float x = (float)i / samples.Length;
            float y = samples[i]; // �g�`�f�[�^�̒l��y���W�Ɏg�p
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}

