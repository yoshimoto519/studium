using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWaveformVisualizer : MonoBehaviour
{
    public AudioSource audioSource;
    public LineRenderer lineRenderer;

    public int resolution = 1024; // îgå`ÇÃâëúìx
    public float waveformScale = 2.0f; // îgå`ÇÃçÇÇ≥í≤êÆ

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = resolution;
    }

    void Update()
    {
        float[] waveformData = new float[resolution];
        audioSource.GetSpectrumData(waveformData, 0, FFTWindow.Rectangular);

        for (int i = 0; i < resolution; i++)
        {
            float x = (float)i / (resolution - 1);
            float y = waveformData[i] * waveformScale;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
