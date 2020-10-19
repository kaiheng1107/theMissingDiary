using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor(typeof(MySceneManager))]
public class MySceneManagerEditor : Editor
{
    MySceneManager Target;

    private void OnEnable()
    {
        Target = (MySceneManager)target;
        _Update();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Target.Size = EditorGUILayout.IntField("Scene size", Target.Size);

        if (Target.Size > Target.ScenePaths.Count)
        {
            string[] extentions = new string[Target.Size - Target.ScenePaths.Count];
            Target.ScenePaths.AddRange(extentions.ToList());
        }
        else if (Target.Size < Target.ScenePaths.Count)
        {
            Target.ScenePaths.RemoveRange(Target.Size, Target.ScenePaths.Count - Target.Size);
        }

        bool isUpdate = false;

        for (int i = 0; i < Target.ScenePaths.Count; i++)
        {
            var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(Target.ScenePaths[i]);
            var scene = EditorGUILayout.ObjectField($"scene{i + 1}", oldScene, typeof(SceneAsset), false) as SceneAsset;

            if (string.IsNullOrEmpty(Target.ScenePaths[i]) || !scene.Equals(oldScene))
            {
                Target.ScenePaths[i] = AssetDatabase.GetAssetPath(scene);
                isUpdate = true;
            }
        }

        if (isUpdate)
        {
            _Update();
        }

        if (GUILayout.Button("Load all scene"))
        {
            Target.LoadAllScenes();
        }
        if (GUILayout.Button("Go next scene"))
        {
            Target.ChangeToNextScene();
        }
    }
    private void _Update()
    {
        Target.SceneNames = new List<string>();
        foreach (var i in Target.ScenePaths)
        {
            if (string.IsNullOrEmpty(i)) continue;
            SceneAsset scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(i);
            Target.SceneNames.Add(scene.name);
        }
    }
}

