using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;


public class AnimationContTest : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource = null;
    public Animator animator;
    private float threshold = -25.0f;
    private bool Bool = false;
    private const int sample = 1024;
    private float[] data = new float[sample];

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // videoPlayer‚ªÄ¶’†‚È‚çaudioSource‚ğæ“¾
        if (videoPlayer.isPlaying)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // audioSource‚ªæ“¾‚Å‚«‚È‚¢ê‡‚ÍƒGƒ‰[‚ğo—Í
        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found.");
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            audioSource.GetOutputData(data, 0);
            float amplitude = 0f;
            for (int i = 0; i < data.Length; i++)
            {
                amplitude += Mathf.Abs(data[i]);
            }
            amplitude /= data.Length;
            var db = 20.0f * Mathf.Log10(amplitude);
            Debug.Log(db);
            //int hashRandom = Animator.StringToHash("random");
            //animator.SetInteger(hashRandom, Random.Range(0, 4));
            if (db > threshold)
            {
                animator.SetBool("Bool", true);
                int hashRandom = Animator.StringToHash("random");
                animator.SetInteger(hashRandom, Random.Range(0, 6));
                /*int min = 0;
                int max = 4;
                int random = Random.Range(min, max);
                */
                
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f && db <= threshold )
            {
               animator.SetBool("Bool", false);
            }
        }
    }
}
