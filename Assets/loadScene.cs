using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{

    public GameObject[] _gms;

    // Start is called before the first frame update
    void Start()
    {
       foreach(GameObject g in _gms)
        {
            DontDestroyOnLoad(g);
        }

        SceneManager.LoadScene(1,LoadSceneMode.Additive);

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
