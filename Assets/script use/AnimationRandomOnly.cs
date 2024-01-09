using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;


public class AnimationRandomOnly : MonoBehaviour
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


    }
    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            int hashRandom = Animator.StringToHash("random");
            animator.SetInteger(hashRandom, Random.Range(0, 5));
            animator.SetBool("Bool", true);
        }
    }
}
