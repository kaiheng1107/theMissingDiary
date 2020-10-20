using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenePreserve : MonoBehaviour
{

    public GameObject[] _gms;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject g in _gms)
        {
            DontDestroyOnLoad(g);
        }

        //SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
