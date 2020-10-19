using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AutoSetMat))]
public class AutoSetMatEditor : Editor
{
    private AutoSetMat Target;

    private void OnEnable()
    {
        Target = (AutoSetMat)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Apply"))
        {
            Target.SetMaterials();
        }

        if (GUILayout.Button("Find material by path")
            && _TryGetMatFromPath(Target.Path + "/" + Target.name+".mat", out object obj))
        {
            var mat = (Material)obj;
            Target.SetMaterials(mat);
        }

        if(GUILayout.Button("Random book material"))
        {
            Target.SetBookMaterials();
        }
    }
    private bool _TryGetMatFromPath(string path, out object obj)
    {
        try
        {
            obj = AssetDatabase.LoadAllAssetsAtPath(path);
            return obj != null;
        }
        catch
        {
            //TODO
            obj = null;
            return false;
        }
    }
}
