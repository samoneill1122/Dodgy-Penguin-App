using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour { 

    public Sound[] sounds;
    public Slider volSlider;
    string loadedScene;

    public static AudioManager instance;

	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Play("MainMenuTheme");
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Play("LevelTheme");
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Play("GameOverTheme");
        }
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("Level " + level);
        if(level == 0)
        {
            Play("MainMenuTheme");
            Stop("LevelTheme");
            Stop("GameOverTheme");
        }
        if (level == 1)
        {
            Play("LevelTheme");
            Stop("MainMenuTheme");
            Stop("GameOverTheme");
        }
        if (level == 2)
        {
            Play("GameOverTheme");
            Stop("MainMenuTheme");
            Stop("LevelTheme");
          /*  if (AdScript.adPlaying)
            {
                Pause("GameOverTheme");
                Stop("MainMenuTheme");
                Stop("LevelTheme");
            }
            else if(!AdScript.adPlaying)
            {
                UnPause("GameOverTheme");
                Stop("MainMenuTheme");
                Stop("LevelTheme");
            } */
        }
    }

    // Update is called once per frame
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
	}

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Pause();
    }

    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.UnPause();
    }

    public void changeVolume()
    {
        AudioListener.volume = volSlider.value;
    }

}
