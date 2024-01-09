using UnityEngine;
using UnityEngine.Video;

public class VideoCnt : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public KeyCode playKey = KeyCode.S;      // ����Đ��Ɏg�p����L�[
    public KeyCode skipKey = KeyCode.Space;  // 30�b�X�L�b�v�Ɏg�p����L�[
    public KeyCode pauseKey = KeyCode.Return;
    //public KeyCode stopKey = KeyCode.T;// �ꎞ��~�Ɏg�p����L�[
    public float skipDuration = 30f;         // �X�L�b�v����b��

    private void Start()
    {
        // VideoPlayer�̏����ݒ�Ȃǂ��s���ꍇ�͂����ɒǉ�
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer not assigned!");
            return;
        }

        // �X�L�b�v�\�ȏ�ԂɑJ�ڂ��邽�߂̃��X�i�[��o�^
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void Update()
    {
        if (Input.GetKeyDown(playKey))
        {
            PlayVideo();
        }

        if (Input.GetKeyDown(skipKey))
        {
            SkipVideo();
        }
        if (Input.GetKeyDown(pauseKey))
        {
            PauseVideo();
        }
    }

    private void PlayVideo()
    {
        // ���悪�Đ����łȂ���΍Đ�
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }

    private void SkipVideo()
    {
        // ���悪�Đ����ł���΃X�L�b�v
        if (videoPlayer.isPlaying)
        {
            // ����̍Đ��ʒu�ɃX�L�b�v����b�������Z
            videoPlayer.time += skipDuration;
        }
    }

    
    private void PauseVideo()
    {
        // ���悪�Đ����Ȃ�ꎞ��~�܂��͍Đ���؂�ւ�
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }

    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // ���悪�I�������Ƃ��̏����i�����ŉ�������̏I���������s���j
        Debug.Log("Video End");
    }
}
