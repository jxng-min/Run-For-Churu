using System.Collections;
using System.Collections.Generic;
using _State;
using UnityEngine;

public class PlayerDeadState : MonoBehaviour, IPlayerState
{
    private PlayerCtrl m_player_ctrl;
    public void Handle(PlayerCtrl ctrl)
    {
        if(!m_player_ctrl)
            m_player_ctrl = ctrl;
            
        SoundManager.Instance.PlaySE("Dead");
        m_player_ctrl.m_animator.SetTrigger("Dead");
        GameManager.m_game_state = GameManager.GameState.DEAD;
    }
}