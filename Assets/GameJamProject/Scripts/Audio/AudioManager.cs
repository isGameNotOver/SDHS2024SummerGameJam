using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManagerInstance { get; private set; }

    [SerializeField] AudioMixer audioMixer;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource effectSource;

    public float volumeMaster;
    public float volumeBGM;
    public float volumeSFX;

    private void Awake()
    {
        if (audioManagerInstance == null)
        {
            audioManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void PlayBGM(AudioClip clip)
    {
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void PlayEffect(AudioClip clip)
    {
        // PlayOneShot 메서드 사용
        effectSource.PlayOneShot(clip);
    }
}
