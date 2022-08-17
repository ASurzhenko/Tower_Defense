using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public enum SoundEnum
{
    EnemyDeath = 0,
    GameOverSound = 1,
    WinSound = 2,
    CoinSound = 3,
    Shoot = 4
}

public class AudioManager : MonoBehaviour
{
    public static bool HasInitialised { get; private set; }
    public static AudioManager Instance;
    static string GameSFX = "GameSFX";
    public static bool GameSfx
    {
        get
        {
            return PlayerPrefs.GetInt(GameSFX) == 0;
        }
        set
        {
            PlayerPrefs.SetInt(GameSFX, value ? 0 : 1);
        }
    }

    public AudioListener audioListener;
    public AudioSource sfxAud, musicAud, shootAud;
    public List<SoundsData_SO> gameSounds_SO = new List<SoundsData_SO>();
    private void Start() {
        if (HasInitialised) return;
        HasInitialised = true;
    }
    void Awake()
    {
        Instance = this;

        // if user is starting for the first time then set the sound and other settings.
        if (PlayerPrefs.HasKey("firstsound") == false)
        {
            PlayerPrefs.SetInt("firstsound", 1);

            PlayerPrefs.SetFloat("music_volume", 0.3f);
            PlayerPrefs.SetFloat("sound_volume", 1f);
            PlayerPrefs.SetFloat("ambient_volume", 0.6f);
        }

        musicAud.volume = PlayerPrefs.GetFloat("music_volume");
        sfxAud.volume = PlayerPrefs.GetFloat("sound_volume");

        if (!isSfxOn())
        {
            audioListener.enabled = false;
        }
    }

    // check to see if the game sfx sounds are on
    public bool isSfxOn()
    {
        return GameSfx;
    }

    // check to see if game music sounds are on
    public bool isMusicOn()
    {
        return GameSfx; 
    }

    // get the volume of music
    public float GetMusicVolume()
    {
        return musicAud.volume;
    }

    // get the volume of sfx
    public float GetSfxVolume()
    {
        return sfxAud.volume;
    }

    // ================================================================== SOUND FUNCTIONS ===========================================================================================================================
    private void OnEnable()
    {
        //MusicSoundStatusChangeEvents add
        //SfxStatusChangeEvents add
    }

    private void OnDisable()
    {
        //MusicSoundStatusChangeEvents add
        //SfxStatusChangeEvents add
    }
    void OnSfxStatusChange(bool _isSFX)
    {
        audioListener.enabled = _isSFX;
    }
    public void PlaySound(SoundEnum soundType)
    {
        try{
            
            gameSounds_SO.Find(x => x.soundType.Equals(soundType)).PlaySound();
        }catch(Exception e){Debug.LogError($"Not found sound {soundType}");}
    }

    public void PlaySound(AudioClip sound)
    {
        if (isSfxOn())
        {
            sfxAud.PlayOneShot(sound);
        }
    }

    public AudioClip GetSound(SoundEnum soundType)
    {
        return gameSounds_SO.Find(x => x.soundType.Equals(soundType)).sound;
    }

    public void PlaySoundWithFade(AudioSource source, AudioClip clip, float volume, float StopTime, float FadeTailTime)
    {
        if (isSfxOn())
        {
            source.clip = clip;
            source.volume = volume;
            source.Play();
            // Make sure that the fadeTaleTime does not go more then the lenght of the clip.
            FadeTailTime = Mathf.Min(FadeTailTime, clip.length - StopTime);
            StartCoroutine(FadeAudio(source, StopTime, FadeTailTime));
        }
    }
    IEnumerator FadeAudio(AudioSource s, float time, float FadeTailTime)
    {
        bool startedFading = false;
        float f = 0;
        while (true)
        {
            if (f > time && !startedFading)
            {
                if(s != null)
                {
                    //Debug.Log(">> Starting to fade sound");
                    DOTween.To(() => s.volume, x => s.volume = x, 0, FadeTailTime).OnComplete(delegate
                    {
                    //  Debug.Log(">> Sound Fade Complete");
                    });
                }
                
                startedFading = true;
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                f += 0.1f;
            }
        }
    }
}
