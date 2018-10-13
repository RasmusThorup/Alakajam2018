using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationalSpeed;

    private void Update ()
    {
        transform.Rotate(rotationalSpeed * Time.deltaTime);	
	}
}
