using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private Animator m_animator;
    private BoxCollider2D m_coll;

    private bool m_is_on_ground = false;

    [SerializeField]
    private float m_jump_power = 15f;

    [SerializeField]
    private LayerMask m_ground_layer;

    private bool m_is_crouch = false;

    [SerializeField]
    private float m_axis_h;

    void Start()
    {
        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();
        m_coll = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(GameManager.game_state == GameManager.GameState.PLAYING)
        {
            m_axis_h = Input.GetAxisRaw("Vertical");
            OnGround();
        }
    }

    void FixedUpdate()
    {
        if(GameManager.game_state == GameManager.GameState.PLAYING)
            SetPlayerState();
    }

    void SetPlayerState()
    {
        if(m_axis_h > 0f && m_is_on_ground && m_is_crouch == false)
        {
            Jump();
            SoundManager.m_instance.PlaySE("Jump");
        }
        else if(m_axis_h < 0f && m_is_on_ground)
        { 
            Crouch();
            m_is_crouch = false;
        }
        else
        {
            m_coll.offset = new Vector2(0f, 0.065f);
            m_coll.size = new Vector2(0.16f, 0.13f);
            m_animator.SetBool("IsCrouch", false);
        }
    }

    void OnGround()
    {
        m_is_on_ground = Physics2D.Linecast(transform.position,
                                        transform.position - (transform.up * 0.1f),
                                        m_ground_layer);
    }

    void Jump()
    {
        Debug.Log(Time.deltaTime);
        m_rigidbody.AddForce(Vector2.up * m_jump_power, ForceMode2D.Impulse);
        m_animator.SetTrigger("Jump");
    }

    void Crouch()
    {
        m_is_crouch = true;
        m_animator.SetBool("IsCrouch", true);
        m_coll.offset = new Vector2(0f, 0.03f);
        m_coll.size = new Vector2(0.16f, 0.06f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = m_is_on_ground ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.1f);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("OBJECT"))
        {
            SoundManager.m_instance.PlaySE("Dead");
            m_animator.SetTrigger("Dead");
            GameManager.m_instance.GameOver();
        }
    }
}
