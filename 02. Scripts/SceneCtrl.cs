using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
    [SerializeField]
    private string m_name;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchScene();
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(m_name);
    }
}
