using UnityEngine;

/// <summary>
/// Manages the audio-related functionality for the game.
/// </summary>
/// <remarks>
/// This class is responsible for handling audio-related tasks such as playing sound clips.
/// <br>It requires an AudioSource component to be attached to the same GameObject.</br>
/// </remarks>
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    //public Sounds sounds;
    public AudioSource audioSource;
    public static SoundManager instance;

    void Awake()
    {
        if (instance == null) { instance = this; }
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays a given audio clip using PlayOneShot with an option to control whether it's valid for playback only once.
    /// <param name="_clip"><br>The audio clip to be played.</br></param>
    /// <param name="validForOnce"></param>
    /// </summary>
    /// <returns>
    /// <list type="bullet">
    /// <item><description><b>True:</b> If the audio is valid for playback only once.</description></item>
    /// <item><description><b>False:</b> If the audio can be played multiple times.</description></item>
    /// </list></returns>
    public void PlayClipOneShot(AudioClip _clip, bool validForOnce)
    {
        // Stop any currently playing audio.
        audioSource.Stop();

        // Check if the audio source is not currently playing and it's not set to be valid for only one playback.
        if (!audioSource.isPlaying && !validForOnce)
        {
            // Play the provided audio clip using PlayOneShot.
            audioSource.PlayOneShot(_clip);
        }
    }

    /// <summary>
    /// Plays a given audio clip using PlayOneShot, stopping any currently playing audio.
    /// </summary>
    /// <param name="_clip">The audio clip to be played.</param>
    public void PlayClipOneShot(AudioClip _clip)
    {
        // Stop any currently playing audio.
        audioSource.Stop();

        // Check if the audio source is not currently playing.
        if (!audioSource.isPlaying)
        {
            // Play the provided audio clip using PlayOneShot.
            audioSource.PlayOneShot(_clip);
        }
    }
}