using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SetVelocity : MonoBehaviour
{
    public bool constant = true;
    public Vector3 velocity;

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(!constant)
        {
            return;
        }

        SetVelocityNow();
    }

    public void SetVelocityNow()
    {
        rigidbody.velocity = velocity;
    }
}