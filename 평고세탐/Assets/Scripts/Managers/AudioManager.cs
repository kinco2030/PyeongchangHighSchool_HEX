using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public AudioClip gameover;
    public AudioClip background;
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameManager.Instance.gameover == true)
        {
            PlayGameOver();
        }
        else if (GameManager.Instance.gameover == false)
        {
            PlayBGM();
        }
    }

    private void PlayGameOver()
    {
        m_AudioSource.loop = false;
        m_AudioSource.clip = gameover;
        m_AudioSource.Play();
    }

    private void PlayBGM()
    {
        m_AudioSource.loop = true;
        m_AudioSource.clip = background;
        m_AudioSource.Play();
    }
}
