using UnityEngine;

public class DestroyWhen : MonoBehaviour
{
    public Value destroyWhen;
    public Condition @is;
    public float than;

    private float lifeTime;

    private void Update()
    {
        lifeTime += Time.deltaTime;

        float val = 0;

        switch(destroyWhen)
        {
            case Value.X_POSITION:
                val = transform.position.x;
                break;
            case Value.Y_POSITION:
                val = transform.position.y;
                break;
            case Value.Z_POSITION:
                val = transform.position.z;
                break;
            case Value.LIFE_TIME:
                val = lifeTime;
                break;
        }

        if(@is == Condition.GREATER)
        {
            if(val > than)
            {
                Destroy(gameObject);
            }
        }
        else if (@is == Condition.LESS)
        {
            if (val < than)
            {
                Destroy(gameObject);
            }
        }
    }

    public void DestroyNow()
    {
        Destroy(gameObject);
    }

    public enum Value
    {
        X_POSITION,
        Y_POSITION,
        Z_POSITION,
        LIFE_TIME
    }

    public enum Condition
    {
        GREATER,
        LESS
    }
}