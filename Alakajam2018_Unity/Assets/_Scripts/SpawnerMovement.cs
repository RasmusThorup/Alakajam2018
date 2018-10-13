using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour {

    public Transform player;
    public Vector3 distance = new Vector3(0, 2, 0);
   
    public float offset = 20f;

    public float speed = 1;
    private float time;


    void Start () {
        //Transform transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

       

        Vector3 last = (distance * offset) + distance * CalculateSine(time);

        time += Time.deltaTime / distance.magnitude * speed;

        if (time >= 1)
        {
            time = time - 1;
        }

        Vector3 now = (distance * offset) + distance * CalculateSine(time);

        Vector3 XandZ = transform.position += now - last;

        transform.position = new Vector3(XandZ.x, player.transform.position.y + offset, XandZ.z);

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
