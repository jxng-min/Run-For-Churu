using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCtrl : MonoBehaviour
{
    public void SetStateSetting()
    {
        GameManager.m_game_state = GameManager.GameState.SETTING;
    }

    public void SetStatePlaying()
    {
        GameManager.m_game_state = GameManager.GameState.PLAYING;
    }

    public void SetStateDead()
    {
        GameManager.m_game_state = GameManager.GameState.DEAD;
    }
}