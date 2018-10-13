using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AutoForce : MonoBehaviour
{
    public Interval interval;
    public Vector3 force;
    public ForceMode forceMode;

    private new Rigidbody rigidbody;
    private float time;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (interval == Interval.ON_START)
        {
            AddForce();
        }
    }

    private void Update()
    {
        if(interval == Interval.ON_START)
        {
            return;
        }

        if(interval == Interval.ON_UPDATE)
        {
            AddForce();
        }
        else if(interval == Interval.EVERY_SECOND)
        {
            time += Time.deltaTime;
            if(time >= 1)
            {
                time = time - 1;
                AddForce();
            }
        }
    }

    private void AddForce()
    {
        rigidbody.AddForce(force, forceMode);
    }

    public enum Interval
    {
        ON_START,
        ON_UPDATE,
        EVERY_SECOND
    }
}