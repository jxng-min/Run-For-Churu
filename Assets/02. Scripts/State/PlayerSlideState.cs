using System.Collections;
using System.Collections.Generic;
using _State;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerSlideState : MonoBehaviour, IPlayerState
{
    private PlayerCtrl m_player_ctrl;

    public void Handle(PlayerCtrl ctrl)
    {
        if(!m_player_ctrl)
            m_player_ctrl = ctrl;

        Crouch();
    }

    void Crouch()
    {
        m_player_ctrl.m_is_crouch = true;
        m_player_ctrl.m_animator.SetBool("IsCrouch", true);
        m_player_ctrl.m_coll.offset = new Vector2(0f, 0.03f);
        m_player_ctrl.m_coll.size = new Vector2(0.16f, 0.06f);
        m_player_ctrl.m_is_crouch = false;
    }
}
