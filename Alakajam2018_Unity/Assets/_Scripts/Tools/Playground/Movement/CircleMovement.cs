using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float radius = 1;
    public float speed = 1;

    private void Update()
    {
        transform.RotateAround(transform.position - transform.forward * radius, transform.up, LengthOfOneDegree() * Time.deltaTime * speed);
    }

    private float Circumfrence()
    {
        return radius * Mathf.PI * 2;
    }

    private float LengthOfOneDegree()
    {
        return 1 / ((Circumfrence()) / 360);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (!enabled) return;

        UnityEditor.Handles.Disc(transform.rotation, transform.position - transform.forward * radius, transform.up, radius, false, 0);
    }
#endif
}