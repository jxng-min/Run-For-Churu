using System.Collections;
using System.Collections.Generic;
using _State;
using UnityEngine;

public class PlayerJumpState : MonoBehaviour, IPlayerState
{
    private PlayerCtrl m_player_ctrl;

    public void Handle(PlayerCtrl ctrl)
    {
        if(!m_player_ctrl)
            m_player_ctrl = ctrl;

        SoundManager.Instance.PlaySE("Jump");
        Jump();
    }

    void Jump()
    {
        m_player_ctrl.m_rigidbody.AddForce(Vector2.up * m_player_ctrl.m_jump_power, ForceMode2D.Impulse);
        m_player_ctrl.m_animator.SetTrigger("Jump");
    }
}