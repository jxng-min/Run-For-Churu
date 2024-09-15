using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusRespawnCtrl : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_cactus_pool = new List<GameObject>();
    
    [SerializeField]
    private GameObject[] m_objs;

    private int m_obj_count = 1;

    [SerializeField]
    private float m_spawn_end_time = 3.0f;
    void Awake()
    {
        for(int i = 0; i < m_objs.Length; i++)
            for(int j = 0; j < m_obj_count; j++)
                m_cactus_pool.Add(CreateObj(m_objs[i], transform));
    }

    IEnumerator CreateCactus()
    {
        while(true)
        {
            m_cactus_pool[SelectDeactivateCactus()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f, m_spawn_end_time));
        }
    }

    int SelectDeactivateCactus()
    {
        List<int> deactive_list = new List<int>();

        for(int i = 0; i < m_cactus_pool.Count; i++)
        {
            if(!m_cactus_pool[i].activeSelf)
                deactive_list.Add(i);
        }

        int num = 0;
        if(deactive_list.Count > 0)
            num = deactive_list[Random.Range(0, deactive_list.Count)];

        return num;
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);

        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }

    void PlayGame(GameManager.GameState game_state)
    {
        if(game_state == GameManager.GameState.PLAYING)
        {
            for(int i = 0; i < m_cactus_pool.Count; i++)
            {
                if(m_cactus_pool[i].activeSelf)
                    m_cactus_pool[i].SetActive(false);
            }
            StartCoroutine(CreateCactus());
        }
        else
        {
            StopAllCoroutines();
            m_spawn_end_time = 3.0f;
        }
    }

    void Start()
    {
        StartCoroutine(CreateCactus());
        GameManager.Instance.StateFunc += PlayGame;
        Invoke("SetSpawnTime", 10f);
    }

    void SetSpawnTime()
    {
        if(m_spawn_end_time >= 1f)
            m_spawn_end_time -= 0.5f;
        Invoke("SetSpawnTime", 10f);
    }
}
