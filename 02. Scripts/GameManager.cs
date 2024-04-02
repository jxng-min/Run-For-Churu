using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager m_instance;
    private void Awake()
    {
        if(m_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            m_instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    public enum GameState
    {
        PLAYING = 1,
        DEAD = 2
    }

    public static GameState game_state;
    public delegate void OnPlay(GameState game_state);
    public OnPlay StateFunc;

    [SerializeField]
    private GameObject m_dead_panel;

    [SerializeField]
    private TextMeshProUGUI m_score_board;

    [SerializeField]
    private TextMeshProUGUI m_high_score_board;

    [SerializeField]
    private GameObject m_player;

    private int m_score = 0;

    void Start()
    {
        Play();
    }

    void Update()
    {   
        if(GameManager.game_state == GameState.DEAD
            && Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
    }

    public void Play()
    {
        m_score = 0;
        int high_score = PlayerPrefs.GetInt("HighScore", 0);
        m_high_score_board.text = ConvertScore(high_score);

        m_player.GetComponent<Animator>().SetTrigger("Run");

        CactusCtrl.m_cactus_speed = 10.0f;

        if(m_dead_panel.activeSelf)
            m_dead_panel.SetActive(false);

        game_state = GameState.PLAYING;
        StateFunc.Invoke(game_state);
        StartCoroutine(AddScore());
    }

    public void GameOver()
    {
        m_dead_panel.SetActive(true);
        game_state = GameState.DEAD;
        StateFunc.Invoke(game_state);

        StopCoroutine(AddScore());

        int high_score = PlayerPrefs.GetInt("HighScore", 0);

        if (high_score < m_score)
        {
            PlayerPrefs.SetInt("HighScore", m_score);
            m_high_score_board.text = ConvertScore(m_score);
        }

        Debug.Log(m_score + " " + PlayerPrefs.GetInt("HighScore", 0));
    }

    IEnumerator AddScore()
    {
        while(game_state == GameState.PLAYING)
        {
            m_score++;
            m_score_board.text = ConvertScore(m_score);
            yield return new WaitForSeconds(0.1f);
        }
    }

    string ConvertScore(int num)
    {
        return string.Format("{0:D5}", num);
    }
}
