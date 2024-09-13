using System.Collections;
using System.Collections.Generic;
using _Singleton;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip m_clip;
}

public class SoundManager : Singleton<SoundManager>
{
    public Sound[] m_effect_sounds;
    public AudioSource[] m_audio_source_effects;
    public string[] m_player_sound_name;

    void Start()
    {
        m_player_sound_name = new string[m_audio_source_effects.Length];
    }

    public void PlaySE(string _name)
    {
        for (int i = 0; i < m_effect_sounds.Length; i++)
        {
            if(_name == m_effect_sounds[i].name)
            {
                for (int j = 0; j < m_audio_source_effects.Length; j++)
                {
                    if(!m_audio_source_effects[j].isPlaying)
                    {
                        m_audio_source_effects[j].clip = m_effect_sounds[i].m_clip;
                        m_audio_source_effects[j].Play();
                        m_audio_source_effects[j].volume = 0.5f;
                        m_player_sound_name[j] = m_effect_sounds[i].name;
                        return;
                    }
                }
                return;
            }
        }
    }

    public void StopAllSE()
    {
        for (int i = 0; i < m_audio_source_effects.Length; i++)
        {
            m_audio_source_effects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for (int i = 0; i < m_audio_source_effects.Length; i++)
        {
            if(m_player_sound_name[i] == _name)
            {
                m_audio_source_effects[i].Stop();
                break;
            }
        }
    }
}