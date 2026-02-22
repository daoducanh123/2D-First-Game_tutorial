using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // AudioSource: stereo play music
    [SerializeField] private AudioSource  backgroundAudioSource;
    [SerializeField] private AudioSource effectAudioSource;
    // AudioClip: File
    [SerializeField] private AudioClip backgroundAudioClip;
    [SerializeField] private AudioClip jumpClip, coinClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayBackGroundMusic();
    }

    public void PlayBackGroundMusic()
    {
        backgroundAudioSource.clip = backgroundAudioClip;
        backgroundAudioSource.volume = 0.3f;
        backgroundAudioSource.Play();
    }    
    
    public void PlayJumpSound()
    {
        effectAudioSource.PlayOneShot(jumpClip);
    }
    public void PlayCoinSound()
    {
        effectAudioSource.PlayOneShot(coinClip);
    }

}
