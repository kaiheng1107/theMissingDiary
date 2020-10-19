using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DiaryFXController))]
public class DiaryFXControllerEditor : Editor
{
    DiaryFXController Target;
    private void OnEnable()
    {
        Target = (DiaryFXController)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Preview"))
        {
            Target.PlayAnimation();
        }

        if(GUILayout.Button("Reset"))
        {
            Target.Reset();
        }
    }
}
