using System;
using UnityEngine;
using UnityEngine.Audio;

public class Soundmanager : MonoBehaviour
{
    public static Soundmanager Instance;
    public Sound[] musicSounds,sfxSounds;
    public AudioSource musicSource, sfxSource;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        
       }

    
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.name == name);
        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
       
    }

    // Update is called once per framecc
    public void PlaySfx(string name)
    {

        Sound s = Array.Find(sfxSounds, sound => sound.name == name);
        if (s != null)
        {

            sfxSource.PlayOneShot(s.clip);
        }

    }
}
