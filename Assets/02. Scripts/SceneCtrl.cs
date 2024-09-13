using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
    public string m_name;

    public void SwitchScene()
    {
        SceneManager.LoadScene(m_name);
    }
}
