using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AnimationPlayer))]
public class AnimatorPlayer : Editor
{
    private AnimationPlayer Target;

    private void OnEnable()
    {
        Target = (AnimationPlayer)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Play"))
        {
            Target.Play();
        }
    }
}
