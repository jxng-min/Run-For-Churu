using UnityEngine;
using UnityEngine.UI;
using _Singleton;
using System.ComponentModel;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        SETTING, PLAYING, DEAD
    }

    public GameObject m_state_panel;
    public GameObject m_dead_panel;
    public delegate void OnPlay(GameState game_state);
    public OnPlay StateFunc;

    public GameState State { get; private set; }


    private void Start()
    {
        DontDestroyOnLoad(m_state_panel);
        Setting();
    }

    public void Setting()
    {
        State = GameState.SETTING;

        m_dead_panel.SetActive(false);
    }

    public void Playing()
    {
        State = GameState.PLAYING;

        m_dead_panel.SetActive(false);
    }

    public void Dead()
    {
        State = GameState.DEAD;

        PlayerCtrl player_ctrl = FindObjectOfType<PlayerCtrl>();
        if(player_ctrl)
            player_ctrl.DeadPlayer();

        m_dead_panel.SetActive(true);
    }
}
