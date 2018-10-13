using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
    public TriggerType triggerOn;
    public UnityEvent action;
    public Transform onlyWorkOnObject;
    public string onlyWorkOnTag;

    private void OnTriggerEnter(Collider other)
    {
        if(triggerOn == TriggerType.ENTER)
        {
            if (IsValid(other))
            {
                action.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerOn == TriggerType.EXIT)
        {
            if(IsValid(other))
            {
                action.Invoke();
            }
        }
    }

    private bool IsValid(Collider other)
    {
        if (onlyWorkOnObject != null)
        {
            return other.transform == onlyWorkOnObject;
        }

        if (!string.IsNullOrEmpty(onlyWorkOnTag))
        {
            return other.CompareTag(onlyWorkOnTag);
        }

        return true;
    }

    public enum TriggerType
    {
        ENTER,
        EXIT
    }
}