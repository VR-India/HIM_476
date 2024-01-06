using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Represents audio data with a name, duration, and associated audio clip.
/// </summary>
[System.Serializable]
public class sound
{
    // The name of the sound.
    public string name;

    // The duration of the sound.
    public float time;

    // The audio clip associated with the sound.
    public AudioClip clip;
}

/// <summary>
/// ScriptableObject for managing audio clips.
/// </summary>
[CreateAssetMenu(fileName = "AudioClips", menuName = "Scriptable/Sounds", order = 1)]
public class Sounds : ScriptableObject
{
    // List of sound objects representing audio clips.
    public List<sound> clips;

    // Indicates whether the instruction is valid for execution only once.
    public bool Instruction_validForOnce = false;

    // Indicates whether loading the scene is valid.
    public bool LoadScene_valid = false;

    /// <summary>
    /// Retrieves an audio clip by name from the list of available clips.
    /// </summary>
    /// <param name="name">The name of the audio clip to retrieve.</param>
    /// <returns>
    /// The <see cref="AudioClip"/> associated with the specified name if found;
    /// otherwise, returns <c>null</c>.
    /// </returns>
    public AudioClip GetClip(string name)
    {
        foreach (var c in clips)
        {
            if (c.name == name)
                return c.clip;
        }
        return null;
    }
}