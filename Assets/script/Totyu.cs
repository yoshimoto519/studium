using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class Totyu : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource = null;
    public Animator animator;
    private bool Bool = false;
    private const int sample = 1024;
    private float[] data = new float[sample];
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (videoPlayer.isPlaying)
            audioSource = GetComponent<AudioSource>();
        
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

            if (db > -20.0f)
            {
                animator.SetBool("Bool", true);
            }else if (db <= -20.0f)
            {
                animator.SetBool("Bool", false);
            }
        }
    }
}
