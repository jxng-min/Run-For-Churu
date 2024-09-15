using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCtrl : MonoBehaviour
{
    public float m_sun_speed = 0.001f;
    public Vector2 m_start_position;

    private void Start()
    {
        transform.position = m_start_position;
    }

    void Update()
    {
        if(GameManager.Instance.State == GameManager.GameState.PLAYING)
        {
            transform.Translate(Vector2.left * Time.deltaTime * m_sun_speed);

            if(transform.position.x < -12)
                gameObject.SetActive(false);
        }
    }
}
