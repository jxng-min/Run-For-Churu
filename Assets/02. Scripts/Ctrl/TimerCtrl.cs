using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCtrl : MonoBehaviour
{
    public static float m_play_time;
    public TextMeshProUGUI m_timer_text;

    private void Start()
    {
        m_play_time = 0.0f;
    }

    void Update()
    {
        if(GameManager.Instance.State == GameManager.GameState.PLAYING)
        {
            m_play_time += Time.deltaTime;
            m_timer_text.text = (m_play_time * 10).ToString("00000");
        }
    }
}
