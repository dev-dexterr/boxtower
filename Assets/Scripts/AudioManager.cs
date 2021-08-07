using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private static AudioManager audioManager = null;

    public static AudioManager GetAudioManager()
    {
        return null;
    }

    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            sound.source = audioSource;
            audioSource.playOnAwake = false;
            audioSource.clip = sound.sound;
            audioSource.volume = sound.volume;
            audioSource.loop = sound.isLoop;
        }

        //DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
        Play("background");
    }

    public void Play(string name)
    {
        Sound sound = sounds.Where(s => s.name == name).FirstOrDefault();
        if (sound != null)
        {
            sound.Play();
        }
    }
}
