using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HighLightEffectController))]
public class HighLightEffectControllerEditor : Editor
{
    HighLightEffectController Target;

    private void OnEnable()
    {
        Target = (HighLightEffectController)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Apply"))
        {
            Target.SetHighlight();
        }
    }
}
