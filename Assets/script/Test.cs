using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public Animator animator = null;
    public float thresholdVolume = 0.1f;
    public bool animationPlaying = false;
    //private bool Bool = false;
    private const int SampleCount = 1024;
    private float[] _samples = new float[SampleCount];
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        // 音量をデシベル単位で取得
        var db = CalcDecibel();

        if (db > thresholdVolume)
        {
            animator.SetBool("animationPlaying",true);
            //animator.SetBool("Bool", true);
        }
        else if(db <= thresholdVolume)
        {
            animator.SetBool("animationPlaying", false);
        }

    }

    private float CalcDecibel()
    {
        audioSource.GetOutputData(_samples, 0);

        var sum = 0.0f;
        foreach (var sample in _samples)
            sum += sample * sample;

        var rmsValue = Mathf.Sqrt(sum / SampleCount);
        var dbValue = 20.0f * Mathf.Log10(rmsValue);
        if (dbValue < -80.0f)
            dbValue = -80.0f;

        return dbValue;
    }
}
