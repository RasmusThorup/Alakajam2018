using UnityEngine;
using UnityEngine.Events;

public class InputReceiver : MonoBehaviour
{
    public KeyCode key;
    public UnityEvent action;

    private void Update()
    {
        if(Input.GetKeyDown(key))
        {
            action.Invoke();
        }    
    }
}