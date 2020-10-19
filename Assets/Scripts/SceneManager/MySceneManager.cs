using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public GameObject m_Ground;
    public static MySceneManager Instance;
    public List<string> ScenePaths = new List<string>();
    public List<string> SceneNames = new List<string>();
    public int Size;

    private void Awake()
    {
        Instance = this;
        var go = Instantiate(m_Ground);
        DontDestroyOnLoad(go);
        //LoadAllScenes();
    }
    public void LoadAllScenes()
    {
        foreach (var i in SceneNames)
        {
            SceneManager.LoadScene(i, LoadSceneMode.Additive);
        }
    }
    public void ChangeToNextScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        var current = SceneNames.IndexOf(currentScene.name);
        var next = current + 1;
        if (next >= ScenePaths.Count) return;
        SceneManager.LoadScene(SceneNames[next]);
    }
}
