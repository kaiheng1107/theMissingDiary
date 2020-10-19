using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitialization : MonoBehaviour
{
    [SerializeField]
    private MySceneManager m_SceneManager;

    private void Awake()
    {
        if (m_SceneManager != null)
            Instantiate(m_SceneManager);

        DontDestroyOnLoad(MySceneManager.Instance);
    }
}
