using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public Animator animator;
    public float thresholdVolume = -20.0f;
    //public bool animationPlaying = false;
    private bool Bool = false;
    private const int SampleCount = 1024;
    private float[] samples = new float[SampleCount];
    private AudioMixer audioMixer;
    private float volume;
    private float currentVolume = -1.0f;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���ʂ��f�V�x���P�ʂŎ擾
        //var db = CalcDecibel();

         //if (db > thresholdVolume)
        // {
             //animator.SetBool("animationPlaying",true);
            // animator.SetBool("Bool", true);
         //}
        // else if(db <= thresholdVolume)
        // {
             //animator.SetBool("animationPlaying", false);
            // animator.SetBool("Bool", false);

        // }
        //var db = VolumeCLK();
        /*audioMixer.GetFloat("BGMVolume", out volume);
        var db = volume;
        if (db > thresholdVolume)
        {
            //animator.SetBool("animationPlaying",true);
            animator.SetBool("Bool", true);
        }
        else if (db <= thresholdVolume)
        {
            //animator.SetBool("animationPlaying", false);
            animator.SetBool("Bool", false);
        }*/

    }

    //private float VolumeCLK()
    //{
        //if (Mathf.Approximately(currentVolume, volume))

        // AudioMixer.SetFloat �� Exposed Parameter ��ݒ肷��
        //audioMixer.GetFloat("BGMVolume", out volume);
        //currentVolume = volume;
       // return volume;
        //Debug.Log("Current Volume: " + currentVolume + " dB");
   // }

    /*private float CalcDecibel()
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
    }*/
}
