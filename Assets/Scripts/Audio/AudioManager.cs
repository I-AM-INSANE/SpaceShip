using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    #region Properties

    public static bool Initialized
    {
        get { return initialized; }
    }

    #endregion

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Explosion, Resources.Load<AudioClip>("Explosion"));
        audioClips.Add(AudioClipName.Shot, Resources.Load<AudioClip>("Shot"));
        audioClips.Add(AudioClipName.Drive, Resources.Load<AudioClip>("Drive"));
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}

