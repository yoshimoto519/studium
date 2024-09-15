using System.Collections;
using UnityEngine.Video;
using UnityEngine;

public class Otamesi : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public Animator animator;

    private const float threshold = -22.0f;
    private const int sample = 1024;
    private float[] data = new float[sample];

    void Start()
    {
        animator = GetComponent<Animator>();

        if (videoPlayer.isPlaying)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found.");
        }
    }

    void Update()
    {
        if (videoPlayer.isPlaying && audioSource != null)
        {
            float db = GetAudioAmplitude();
            HandleAnimation(db);
            animator.SetInteger("random1", Random.Range(0, 3));
        }
    }

    float GetAudioAmplitude()
    {
        audioSource.GetOutputData(data, 0);
        float amplitude = 0f;
        for (int i = 0; i < data.Length; i++)
        {
            amplitude += Mathf.Abs(data[i]);
        }
        return 20.0f * Mathf.Log10(amplitude / data.Length);
    }

    void HandleAnimation(float db)
    {
        
        if (db > threshold)
        {
            animator.SetBool("Bool", true);
            animator.SetInteger("random2", Random.Range(0, 6));
        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).loop && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            animator.SetBool("Bool", false);
        }
    }
}