using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SomiLoadScene : MonoBehaviour
{
    [SerializeField]
    private RawImage[] m_RawImages;
    private void Start()
    {
        for (int i = 0; i < m_RawImages.Length; i++)
        {
            SceneManager.LoadScene(i+1, LoadSceneMode.Additive);
        
        }
    }


}
