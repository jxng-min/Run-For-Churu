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
        if(GameManager.Instance.State == GameManager.GameState.PLAYING)
        {
            m_move_speed += 0.001f;
            transform.Translate(-1 * m_move_speed * Time.deltaTime, 0, 0);

            if(transform.position.x <= m_end_pos)
                transform.Translate(-1 * (m_end_pos - m_start_pos), 0, 0);
        }
    }
}
