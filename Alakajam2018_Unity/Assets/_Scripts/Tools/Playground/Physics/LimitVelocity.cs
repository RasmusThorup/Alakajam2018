using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LimitVelocity : MonoBehaviour
{
    public Vector3 maxVelocity = new Vector3(100, 100, 100);

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 velocity = rigidbody.velocity;

        if(Mathf.Abs(velocity.x) > maxVelocity.x)
        {
            velocity.x = maxVelocity.x * Mathf.Sign(velocity.x);
        }

        if (Mathf.Abs(velocity.y) > maxVelocity.y)
        {
            velocity.y = maxVelocity.y * Mathf.Sign(velocity.y);
        }

        if (Mathf.Abs(velocity.z) > maxVelocity.z)
        {
            velocity.z = maxVelocity.z * Mathf.Sign(velocity.z);
        }

        rigidbody.velocity = velocity;
    }
}