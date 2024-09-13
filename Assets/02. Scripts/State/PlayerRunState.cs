using System.Collections;
using System.Collections.Generic;
using _State;
using UnityEngine;

public class PlayerRunState : MonoBehaviour, IPlayerState
{
    private PlayerCtrl m_player_ctrl;
    public void Handle(PlayerCtrl ctrl)
    {
        if(!m_player_ctrl)
            m_player_ctrl = ctrl;

        Run();
    }

    void Run()
    {
        m_player_ctrl.m_coll.offset = new Vector2(0f, 0.065f);
        m_player_ctrl.m_coll.size = new Vector2(0.16f, 0.13f);
        m_player_ctrl.m_animator.SetBool("IsCrouch", false);
    }
}
