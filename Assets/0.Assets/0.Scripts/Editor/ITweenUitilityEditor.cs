
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ITweenUitility))]
public class ITweenUitilityEditor : Editor
{
    

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        ITweenUitility itweenUitility = (ITweenUitility)target;

        var options = new[] { GUILayout.Width(64), GUILayout.Height(32)};

        EditorGUILayout.BeginHorizontal();

        GUILayout.FlexibleSpace();

        /*
        if (GUILayout.Button("Pause", options))
        {
            itweenUitility.OnPauseiTween();
        }

        if (GUILayout.Button("Resume", options))
        {
            itweenUitility.OnResumeiTween();
        }

        if (GUILayout.Button("Re-Start", options))
        {
            itweenUitility.OnRestartiTween();
        }
        */

        OnButton(itweenUitility, options);

        GUILayout.FlexibleSpace();

        EditorGUILayout.EndHorizontal();
    }

    private void OnButton(ITweenUitility itweenUitility, GUILayoutOption[] options)
    {

        if (GUILayout.Button("Pause", options))
        {
            itweenUitility.OnPauseiTween();
        }

        if (GUILayout.Button("Resume", options))
        {
            itweenUitility.OnResumeiTween();
        }

        if (GUILayout.Button("Re-Start", options))
        {
            itweenUitility.OnRestartiTween();
        }
    }

}
