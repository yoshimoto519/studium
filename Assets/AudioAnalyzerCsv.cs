using UnityEngine;
using UnityEngine.Video;
using System.IO;

public class AudioAnalyzerCsv : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    private StreamWriter csvWriter;
    private string csvFilePath = "audio_data.csv";
    private const int sample = 1024;
    private float[] data = new float[sample];

    private void Start()
    {
        
        
            // CSVファイルを作成または開く
            csvWriter = File.AppendText(csvFilePath);

            // CSVファイルのヘッダを書き込む
            csvWriter.WriteLine("Time,Amplitude");

            // VideoPlayerとAudioSourceの設定
            videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);
            videoPlayer.Play();
        
    }

    private void FixedUpdate()
    {
        if (videoPlayer.isPlaying)
        {
            // 音声の音圧を取得してCSVファイルに書き込む
            float amplitude = GetAudioAmplitude();
            csvWriter.WriteLine(Time.time + "," + amplitude);
        }
    }

    private float GetAudioAmplitude()
    {
        audioSource.GetOutputData(data, 0);
        float amplitude = 0f;
        for (int i = 0; i < data.Length; i++)
        {
            amplitude += Mathf.Abs(data[i]);
        }
        amplitude /= data.Length;
        var db = 20.0f * Mathf.Log10(amplitude);
        return db;
    }

    private void OnDestroy()
    {
        if (csvWriter != null)
        {
            // ファイルを閉じる
            csvWriter.Close();
        }
    }
}

