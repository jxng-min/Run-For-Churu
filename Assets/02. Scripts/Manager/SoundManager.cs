using System.Collections;
using System.Collections.Generic;
using _Singleton;
using UnityEngine;

public class SoundManager: Singleton<SoundManager>
{
    public AudioSource m_effect;

    private AudioClip m_button_click;
    private AudioClip m_player_jump;
    private AudioClip m_player_dead;

    private void Start()
    {
        m_button_click = Resources.Load<AudioClip>("07. Audios/Jump");
        m_player_jump = Resources.Load<AudioClip>("07. Audios/Jump");
        m_player_dead = Resources.Load<AudioClip>("07. Audios/Dead");
    }

    public void ButtonClick()
    {
        m_effect.PlayOneShot(m_button_click);
    }

    public void PlayerJump()
    {
        m_effect.PlayOneShot(m_player_jump);
    }

    public void PlayerDead()
    {
        m_effect.PlayOneShot(m_player_dead);
    }
}