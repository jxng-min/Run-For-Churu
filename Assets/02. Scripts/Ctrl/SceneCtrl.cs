using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using _EventBus;

public class SceneCtrl : MonoBehaviour
{
    public string m_name;

    public void SwitchScene()
    {
        GameEventBus.Publish(GameEventType.SETTING);
        SceneManager.LoadScene(m_name);
    }
}
