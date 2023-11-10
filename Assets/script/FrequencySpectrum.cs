using UnityEngine;
using UnityEngine.Video;

public class FrequencySpectrum : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public LineRenderer spectrumRenderer;
    public int resolution = 1024; // �X�y�N�g���̕���\

    private float[] spectrumData;

    void Start()
    {
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);

        spectrumData = new float[resolution];
        spectrumRenderer.positionCount = resolution;
    }

    void Update()
    {
        if (videoPlayer.isPlaying) {
            audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Hamming);

            UpdateSpectrum();
        }
           
    }

    void UpdateSpectrum()
    {
        for (int i = 0; i < resolution; i++)
        {
            float x = (float)((float)i / resolution * videoPlayer.time);
            float y = spectrumData[i] * 10; // �����̒���

            spectrumRenderer.SetPosition(i, new Vector3(x, y, 0f));
        }
    }
}
