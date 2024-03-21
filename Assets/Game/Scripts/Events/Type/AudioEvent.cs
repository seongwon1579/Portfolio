using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Audio_Clip { Heat, Die }

[RequireComponent(typeof(AudioSource))]
public class AudioEvent : Events
{
    public class AudioBundle
    {
        private Dictionary<Audio_Clip, AudioClip> audioClipsDictionary = new Dictionary<Audio_Clip, AudioClip>();

        private AudioClip[] curClips;
        

        public AudioBundle(AudioClip[] clips)
        {
            curClips = clips;
        }

        public Dictionary<Audio_Clip, AudioClip> GetDictionary()
        {
            foreach(var clip in curClips)
            {
                if (Enum.TryParse(clip.name, out Audio_Clip temp))
                    audioClipsDictionary.Add(temp, clip);
            }

            return audioClipsDictionary;
        }
    }

    [SerializeField]
    private AudioClip[] audioClips;

    private AudioSource source;

    IReadOnlyDictionary<Audio_Clip, AudioClip> audioClipDictionary;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        audioClipDictionary = new AudioBundle(audioClips).GetDictionary();
    }

    public override void DoEvent(int e)
    {
        if (audioClipDictionary.ContainsKey((Audio_Clip)e))
        {
            source.clip = audioClipDictionary[(Audio_Clip)e];
            source.Play();
        }
    }    
}
