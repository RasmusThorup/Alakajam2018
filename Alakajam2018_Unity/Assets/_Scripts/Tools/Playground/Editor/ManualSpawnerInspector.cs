using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ManualSpawner)), CanEditMultipleObjects]
public class ManualSpawnerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Spawn"))
        {
            for (int i = 0; i < targets.Length; i++)
            {
                ((ManualSpawner) targets[i]).Spawn();
            }
        }
    }
}