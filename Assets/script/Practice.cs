using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class Practice : MonoBehaviour
{
    public AudioMixer audioMixer;        // InspectorでAudio Mixerを割り当てる
    public VideoPlayer videoPlayer;
    public Animator animator;           // Animatorコンポーネント
    private bool Bool = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            audioMixer.GetFloat("BGMVolume", out float volume);
            Debug.Log(volume);

            // 音量に基づいてアニメーションを制御
            if (volume > -20.0f)
            {
                // 音量が一定以上の場合、アニメーションを開始
                animator.SetBool("Bool", true);

            }
            else if (volume <= -20.0f)
            {
                // 音量が一定以下の場合、アニメーションを停止
                animator.SetBool("Bool", false);
            }
           
        }
    }
}

