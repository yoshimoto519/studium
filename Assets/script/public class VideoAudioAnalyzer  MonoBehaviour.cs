using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoAudioAnalyzer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public LineRenderer lineRenderer;

    public int spectrumResolution = 256; // ��͉𑜓x
    public float updateInterval = 0.1f; // �O���t�X�V�Ԋu
    private float nextUpdate = 0.0f;

    private float[] spectrumData;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();
        spectrumData = new float[spectrumResolution];
    }

    void Update()
    {
        if (Time.time > nextUpdate)
        {
            audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

            // ��̓f�[�^���g�p���ăO���t��`��
            UpdateGraph();

            nextUpdate = Time.time + updateInterval;
        }
    }

    void UpdateGraph()
    {
        lineRenderer.positionCount = spectrumResolution;

        for (int i = 0; i < spectrumResolution; i++)
        {
            float x = (float)i / spectrumResolution;
            float y = spectrumData[i] * 10.0f; // �g�`�̍�������

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}

