using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Trigger Event"))
        {
            Debug.Log("Triggering: " + target);
            ((GameEvent)target).Raise();
        }
    }
}
