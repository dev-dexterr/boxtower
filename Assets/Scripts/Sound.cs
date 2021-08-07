using UnityEngine;

[System.Serializable]

public class Sound
{
    [HideInInspector]
    public AudioSource source;
    public AudioClip sound;
    public string name;
    public float volume;
    public bool isLoop;

    public void Play()
    {
        source.Play();
    }
}
