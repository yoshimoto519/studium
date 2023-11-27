using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class Practice : MonoBehaviour
{
    public AudioMixer audioMixer;        // Inspector��Audio Mixer�����蓖�Ă�
    public VideoPlayer videoPlayer;
    public Animator animator;           // Animator�R���|�[�l���g
    private bool Bool = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Animator�R���|�[�l���g���擾
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            audioMixer.GetFloat("BGMVolume", out float volume);
            Debug.Log(volume);

            // ���ʂɊ�Â��ăA�j���[�V�����𐧌�
            if (volume > -20.0f)
            {
                // ���ʂ����ȏ�̏ꍇ�A�A�j���[�V�������J�n
                animator.SetBool("Bool", true);

            }
            else if (volume <= -20.0f)
            {
                // ���ʂ����ȉ��̏ꍇ�A�A�j���[�V�������~
                animator.SetBool("Bool", false);
            }
           
        }
    }
}

