using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public static SoundController me = null;

    public GameObject audioSourcePrefab;
    public AudioSource[] audioSources;

    void Awake()
    {
        if (me == null)
        {
            DontDestroyOnLoad(this);
            me = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start () {
        audioSources = new AudioSource[64];
        for (int i = 0; i <audioSources.Length; i++)
        {
            audioSources[i] = (Instantiate(audioSourcePrefab) as GameObject).GetComponent<AudioSource>();
            audioSources[i].transform.SetParent(transform);
        }
	}

    void Update()
    {
        // PlaySound(clip, volume, pitch, true);
    }

    public AudioSource PlaySound(AudioClip clip)
    {
        return PlaySound(clip, 1f, 1); // calls override method
    }

    public AudioSource PlaySound(AudioClip clip, float volume, float pitch, bool loop = false) //loop defaults to false, can override to true when calling function
    {
        int index = GetSourceIndex();
        audioSources[index].clip = clip;
        audioSources[index].volume = volume;
        audioSources[index].pitch = pitch;
        audioSources[index].loop = loop;

        audioSources[index].Play();
        return audioSources[index];
    }

    public int GetSourceIndex()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                return i;
            }
        }

        Debug.Log("all audio sources are currently playing: returning index 0");
        return 0;
    }

    public void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }
}
