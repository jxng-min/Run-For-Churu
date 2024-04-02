using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCtrl : MonoBehaviour
{
    #region singleton
    static public BGMCtrl m_instance;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);  
    }
    #endregion singleton

    [SerializeField]
    private string m_name;
    
    void Start()
    {
        SoundManager.m_instance.PlayBGM(m_name);
    }
}

