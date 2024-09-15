using System.Collections;
using System.Collections.Generic;
using _State;
using _EventBus;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Rigidbody2D m_rigidbody;
    public Animator m_animator;
    public BoxCollider2D m_coll;
    public bool m_is_on_ground = false;
    public float m_jump_power = 15f;
    public LayerMask m_ground_layer;
    public bool m_is_crouch = false;

    private IPlayerState m_run_state, m_jump_state, m_slide_state, m_dead_state;
    private PlayerStateContext m_player_state_context;

    private void OnEnable()
    {
        GameEventBus.Subscribe(GameEventType.SETTING, GameManager.Instance.Setting);
        GameEventBus.Subscribe(GameEventType.PLAYING, GameManager.Instance.Playing);
        GameEventBus.Subscribe(GameEventType.DEAD, GameManager.Instance.Dead);
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameEventType.SETTING, GameManager.Instance.Setting);
        GameEventBus.Unsubscribe(GameEventType.PLAYING, GameManager.Instance.Playing);
        GameEventBus.Unsubscribe(GameEventType.DEAD, GameManager.Instance.Dead);        
    }

    private void Start()
    {
        GameEventBus.Publish(GameEventType.PLAYING);

        m_player_state_context = new PlayerStateContext(this);

        m_run_state = gameObject.AddComponent<PlayerRunState>();
        m_jump_state = gameObject.AddComponent<PlayerJumpState>();
        m_slide_state = gameObject.AddComponent<PlayerSlideState>();
        m_dead_state = gameObject.AddComponent<PlayerDeadState>();

        m_player_state_context.Transition(m_run_state);
    }

    private void Update()
    {
        if(GameManager.Instance.State == GameManager.GameState.PLAYING)
            OnGround();
    }

    public void RunPlayer()
    {
        m_player_state_context.Transition(m_run_state);
    }

    public void JumpPlayer()
    {
        m_player_state_context.Transition(m_jump_state);
    }

    public void SlidePlayer()
    {
        m_player_state_context.Transition(m_slide_state);
    }

    public void DeadPlayer()
    {
        m_player_state_context.Transition(m_dead_state);
    }

    private void OnGround()
    {
        m_is_on_ground = Physics2D.Linecast(transform.position,
                                        transform.position - (transform.up * 0.1f),
                                        m_ground_layer);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("OBJECT"))
            GameEventBus.Publish(GameEventType.DEAD);
    }
}
