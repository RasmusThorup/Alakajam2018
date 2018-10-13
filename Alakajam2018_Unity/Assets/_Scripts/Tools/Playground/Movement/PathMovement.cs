using UnityEngine;

public class PathMovement : MonoBehaviour
{
    public Vector3[] points =
    {
        new Vector3(0, 0, 0),
        new Vector3(5, 0, 5),
        new Vector3(-5, 0, 5)
    };

    public float speed = 1;
    public bool smooth;

    private Vector3 lastPosition;
    private float time;
    private int previousPoint = 0;
    private int nextPoint = 1;

    private void Start()
    {
        lastPosition = GetPositionOnPath(0);
    }

    private void Update()
    {
        float distance = Vector3.Distance(points[previousPoint], points[nextPoint]);

        time += Time.deltaTime / distance * speed;
        if(time >= 1)
        {
            time = time - 1;
            previousPoint = nextPoint;
            nextPoint += 1;
            if (nextPoint >= points.Length)
            {
                nextPoint = 0;
            }
        }

        Vector3 newPosition = GetPositionOnPath(smooth ? Mathf.SmoothStep(0, 1, time) : time);

        transform.position += newPosition - lastPosition;
        lastPosition = newPosition;
    }

    private Vector3 GetPositionOnPath(float t)
    {
        return Vector3.Lerp(points[previousPoint], points[nextPoint], t);
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i <= points.Length; i++)
        {
            Vector3 point = points[i % points.Length] + (transform.position - GetPositionOnPath(time));

            if (i < points.Length)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(point, 0.25f);
            }

            if(i > 0)
            {
                Vector3 lastPoint = points[i - 1] + (transform.position - GetPositionOnPath(time));
                Gizmos.DrawLine(lastPoint, point);
            }
        }
    }
}