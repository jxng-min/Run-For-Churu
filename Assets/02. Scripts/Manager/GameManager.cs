using UnityEngine;
using UnityEngine.UI;
using _Singleton;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        SETTING = 0,
        PLAYING = 1,
        DEAD = 2
    }

    public GameObject m_state_panel;
    public GameObject m_dead_panel;
    public static GameState m_game_state;
    public delegate void OnPlay(GameState game_state);
    public OnPlay StateFunc;

    private void Start()
    {
        m_game_state = GameState.SETTING;
        DontDestroyOnLoad(m_state_panel);
    }

    private void Update()
    {
        if(m_game_state == GameState.SETTING)
        {
            m_dead_panel.SetActive(false);
        }
        else if(m_game_state == GameState.PLAYING)
        {
            m_dead_panel.SetActive(false);
        }
        else
        {
            m_dead_panel.SetActive(true);
        }
    }
}
