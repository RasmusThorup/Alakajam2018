using System.Collections.Generic;
using System.Reflection;
using UnityEditor;

[CustomEditor(typeof(LFO))]
public class LFOInspector : Editor
{
    private int selectedIndex;
    private string[] memberNames;

    private SerializedProperty targetProp;
    private SerializedProperty minProp;
    private SerializedProperty maxProp;
    private SerializedProperty frequencyProp;
    private SerializedProperty useCustomCurveProp;
    private SerializedProperty customCurveProp;
    private SerializedProperty memberNameProp;

    private void OnEnable()
    {
        targetProp = serializedObject.FindProperty("target");
        minProp = serializedObject.FindProperty("min");
        maxProp = serializedObject.FindProperty("max");
        frequencyProp = serializedObject.FindProperty("frequency");
        useCustomCurveProp = serializedObject.FindProperty("useCustomCurve");
        customCurveProp = serializedObject.FindProperty("customCurve");
        memberNameProp = serializedObject.FindProperty("memberInfoName");

        memberNames = new string[0];

        UpdateListOfFields();
    }

    private void UpdateListOfFields()
    {
        memberNames = new string[0];
        List<string> memberNameList = new List<string>();

        if (targetProp.objectReferenceValue == null) return;

        System.Type type = targetProp.objectReferenceValue.GetType();
        FieldInfo[] fieldInfos = type.GetFields();
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            if (fieldInfos[i].FieldType == typeof(float))
            {
                memberNameList.Add(fieldInfos[i].Name);

                if (memberNameProp.stringValue == fieldInfos[i].Name)
                {
                    selectedIndex = memberNameList.Count- 1;
                }
            }
        }

        PropertyInfo[] propertyInfos = type.GetProperties();
        for (int i = 0; i < propertyInfos.Length; i++)
        {
            if (propertyInfos[i].PropertyType == typeof(float))
            {
                memberNameList.Add(propertyInfos[i].Name);

                if (memberNameProp.stringValue == propertyInfos[i].Name)
                {
                    selectedIndex = memberNameList.Count - 1;
                }
            }
        }

        memberNames = memberNameList.ToArray();
    }

    public override void OnInspectorGUI()
    {
        if(targetProp.objectReferenceValue == null)
        {
            UpdateListOfFields();
            memberNameProp.stringValue = string.Empty;
        }

        EditorGUI.BeginChangeCheck();

        EditorGUILayout.PropertyField(targetProp);

        EditorGUI.BeginDisabledGroup(targetProp.objectReferenceValue == target);

        if (EditorGUI.EndChangeCheck())
        {
            selectedIndex = 0;

            UpdateListOfFields();
            if (targetProp.objectReferenceValue == null || memberNames.Length == 0)
            {
                memberNameProp.stringValue = string.Empty;
            }
            else
            {
                memberNameProp.stringValue = memberNames[selectedIndex];
            }

            serializedObject.ApplyModifiedProperties();
        }

        EditorGUI.BeginChangeCheck();

        selectedIndex = EditorGUILayout.Popup("Selected Parameter", selectedIndex, memberNames);

        if(EditorGUI.EndChangeCheck())
        {
            memberNameProp.stringValue = memberNames[selectedIndex];
            serializedObject.ApplyModifiedProperties();
            ((LFO) target).UpdateMemberReference();
        }

        EditorGUI.BeginChangeCheck();

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(minProp);
        EditorGUILayout.PropertyField(maxProp);
        EditorGUILayout.PropertyField(frequencyProp);

        EditorGUILayout.PropertyField(useCustomCurveProp);
        if(useCustomCurveProp.boolValue)
        {
            EditorGUILayout.PropertyField(customCurveProp);
        }

        if(EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }

        EditorGUI.EndDisabledGroup();

        if(targetProp.objectReferenceValue == null)
        {
            EditorGUILayout.HelpBox("No target. Drag a component to the target field.", MessageType.Warning);
        } 
        else if(memberNames.Length == 0)
        {
            EditorGUILayout.HelpBox(string.Format("The component ({0}) does not have any parameters that can be controlled by the LFO.", targetProp.objectReferenceValue.GetType().Name), MessageType.Warning);
        }
        else if(targetProp.objectReferenceValue == target)
        {
            EditorGUILayout.HelpBox("Do not try to control the LFO with itself.", MessageType.Error);
        }
    }
}