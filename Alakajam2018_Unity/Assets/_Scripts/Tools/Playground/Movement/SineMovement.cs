using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public Vector3 distance = new Vector3(0, 2, 0);
    public float speed = 1;
    [Range(-0.5f, 0.5f)] public float offset;

    private float time;

    private void Update()
    {
        Vector3 last = (distance * offset) + distance * CalculateSine(time);

        time += Time.deltaTime / distance.magnitude * speed;

        if (time >= 1)
        {
            time = time - 1;
        }

        Vector3 now = (distance * offset) + distance * CalculateSine(time);

        transform.position += now - last;
    }

    private float CalculateSine(float t)
    {
        return Mathf.Sin(t / 1 * Mathf.PI * 2) * 0.5f + 0.5f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Vector3 start = (distance * offset) + transform.position - distance * CalculateSine(time);

        Gizmos.DrawLine(start, start + distance);
        Gizmos.DrawSphere(start, 0.2f);
        Gizmos.DrawSphere(start + distance, 0.2f);
    }
}