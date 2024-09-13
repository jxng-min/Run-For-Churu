using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    public float m_move_speed = 10f;
    public float m_start_pos;
    public float m_end_pos;

    void Update()
    {
        if(GameManager.m_game_state == GameManager.GameState.PLAYING)
        {
            transform.Translate(-1 * m_move_speed * Time.deltaTime, 0, 0);

            if(transform.position.x <= m_end_pos)
                transform.Translate(-1 * (m_end_pos - m_start_pos), 0, 0);

            m_move_speed += 0.001f;
        }
    }
}
