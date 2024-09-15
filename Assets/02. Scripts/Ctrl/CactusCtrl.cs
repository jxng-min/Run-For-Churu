using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusCtrl : MonoBehaviour
{
    public static float m_cactus_speed = 10f;
    public float m_start_pos;
    public float m_end_pos;
    public float m_cactus_y_pos;

    private void OnEnable()
    {
        transform.position = new Vector2(m_start_pos, m_cactus_y_pos);
    }

    void Update()
    {
        if(GameManager.Instance.State == GameManager.GameState.PLAYING)
        {
            m_cactus_speed += 0.001f;
            transform.Translate(-1 * m_cactus_speed * Time.deltaTime, 0, 0);

            if(transform.position.x <= m_end_pos)
                gameObject.SetActive(false);
        }

        if(GameManager.Instance.State == GameManager.GameState.DEAD)
            m_cactus_speed = 10f;
    }
}
