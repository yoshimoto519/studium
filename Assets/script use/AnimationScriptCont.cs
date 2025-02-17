using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class AnimationScriptCont : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public Animation animationComponent;

    public AnimationClip idleClip;
    public AnimationClip actionClip1;
    public AnimationClip actionClip2;
    public AnimationClip actionClip3;

    private const float threshold = -24.0f;
    private const int sample = 1024;
    private float[] data = new float[sample];

    void Start()
    {
        animationComponent = GetComponent<Animation>();

        // アニメーションを登録
        animationComponent.AddClip(idleClip, "Idle");
        animationComponent.AddClip(actionClip1, "Action1");
        animationComponent.AddClip(actionClip2, "Action2");
        animationComponent.AddClip(actionClip3, "Action3");

        // 初期アニメーション再生
        animationComponent.Play("Idle");

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
            int randomIndex = Random.Range(0, 3); // 0,1,2のいずれかを選択
            string animationName = randomIndex == 0 ? "Action1" :
                                   randomIndex == 1 ? "Action2" : "Action3";

            animationComponent.CrossFade(animationName);
        }
        else
        {
            animationComponent.CrossFade("Idle");
        }
    }
}