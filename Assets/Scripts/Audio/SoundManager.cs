using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    //public Sounds sounds;
    public AudioSource audioSource, source2;
    public static SoundManager instance;
    void Awake()
    {
        if (instance == null) { instance = this; }
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayClipOneShot(AudioClip _clip, bool validForOnce)
    {
        audioSource.Stop();
        //source2.Stop();
        if(!audioSource.isPlaying && !validForOnce)
        {
            audioSource.PlayOneShot(_clip);
        }
    }

    public void PlayClipOneShot(AudioClip _clip)
    {
        audioSource.Stop();
        //source2.Stop();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(_clip);
        }
    }
}