using System.Reflection;
using UnityEngine;

// Only for prototyping
public class LFO : MonoBehaviour
{
    public Component target;

    public float min = 0;
    public float max = 1;
    [Range(0f, 10f)] public float frequency = 1;
    public bool useCustomCurve;

    [SerializeField] private AnimationCurve customCurve;
    [SerializeField] private string memberInfoName;
    private FieldInfo fieldInfo;
    private PropertyInfo propertyInfo;

    private float time;

    private void Start()
    {
        UpdateMemberReference();
    }

    public void UpdateMemberReference()
    {
        System.Type type = target.GetType();
        FieldInfo[] fieldInfos = type.GetFields();
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            if (fieldInfos[i].FieldType == typeof(float))
            {
                if (fieldInfos[i].Name == memberInfoName)
                {
                    fieldInfo = fieldInfos[i];
                    return;
                }
            }
        }

        PropertyInfo[] propertyInfos = type.GetProperties();
        for (int i = 0; i < propertyInfos.Length; i++)
        {
            if (propertyInfos[i].PropertyType == typeof(float))
            {
                if (propertyInfos[i].Name == memberInfoName)
                {
                    propertyInfo = propertyInfos[i];
                    return;
                }
            }
        }
    }

    private void Update()
    {
        time += Time.deltaTime * frequency;
        time = time % 1;

        if (target == null) return;
        if (target == this) return;
        if(fieldInfo == null && propertyInfo == null) return;

        float val = 0;

        if(useCustomCurve)
        {
            val = Mathf.LerpUnclamped(min, max, customCurve.Evaluate(time));
        }
        else
        {
            val = Mathf.Lerp(min, max, Mathf.Sin(time * Mathf.PI * 2) * 0.5f + 0.5f);   
        }

        if(fieldInfo != null)
        {
            fieldInfo.SetValue(target, val);
        }
        else if (propertyInfo != null)
        {
            propertyInfo.SetValue(target, val, null);
        }
    }
}