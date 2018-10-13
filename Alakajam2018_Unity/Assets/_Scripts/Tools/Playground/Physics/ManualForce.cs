using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ManualForce : MonoBehaviour
{
    public Vector3 force;
    public ForceMode forceMode;

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void AddForce()
    {
        rigidbody.AddForce(force, forceMode);
    }
}