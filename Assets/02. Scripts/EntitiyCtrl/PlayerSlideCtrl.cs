using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideCtrl : MonoBehaviour
{
    private float m_click_time;
    public float m_min_click_time = 0.1f;
    private bool m_is_click;
    public PlayerCtrl m_player_ctrl;

    public void ButtonDown()
    {
        if(m_player_ctrl.m_is_on_ground)
        {
            m_is_click = true;
            m_player_ctrl.SlidePlayer();
        }
    }

    public void ButtonUp()
    {
        m_is_click = false;

        if(m_click_time >= m_min_click_time)
            m_player_ctrl.RunPlayer();
    }

    private void Update()
    {
        if(m_is_click)
            m_click_time += Time.deltaTime;
        else
            m_click_time = 0f;
    }
}
