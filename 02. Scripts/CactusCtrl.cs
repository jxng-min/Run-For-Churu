using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusCtrl : MonoBehaviour
{
    public static float m_cactus_speed = 10f;

    [SerializeField]
    private Vector2 m_start_position;

    private void OnEnable()
    {
        transform.position = m_start_position;
    }

    void Update()
    {
        if(GameManager.game_state == GameManager.GameState.PLAYING)
        {
            transform.Translate(Vector2.left * Time.deltaTime * m_cactus_speed);

            if(transform.position.x < -12)
                gameObject.SetActive(false);

            m_cactus_speed += 0.001f;
        }

        if(GameManager.game_state == GameManager.GameState.DEAD)
            m_cactus_speed = 10f;
    }
}
