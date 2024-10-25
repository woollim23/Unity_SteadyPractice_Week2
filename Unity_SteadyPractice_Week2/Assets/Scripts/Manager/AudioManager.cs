using UnityEngine;

public class AudioManager : Singletone<AudioManager>
{
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBGM()
    {
        if(audioSource != null)
            audioSource.Play();
    }
}