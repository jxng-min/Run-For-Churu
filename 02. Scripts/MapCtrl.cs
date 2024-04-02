using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    private float m_move_speed = 10f;

    [SerializeField]
    private float m_start_pos;
    [SerializeField]
    private float m_end_pos;

    void Update()
    {
        if(GameManager.game_state == GameManager.GameState.PLAYING)
        {
            transform.Translate(-1 * m_move_speed * Time.deltaTime, 0, 0);

            if(transform.position.x <= m_end_pos)
            ScrollEnd();

            m_move_speed += 0.001f;
        }

        if(GameManager.game_state == GameManager.GameState.DEAD)
            m_move_speed = 10f;
    }

    void ScrollEnd()
    {
        transform.Translate(-1 * (m_end_pos - m_start_pos), 0, 0);
    }
}
