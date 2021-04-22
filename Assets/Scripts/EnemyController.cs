using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected bool dead;
    public Vector2 dieVelocity;
    public float dyingGravityMultiplier = 5;

    protected void Update()
    {
        if (!dead)
        {
            RegularMove();
        }
        else
        {
            DeadMove();
        }
    }

    public void Kill()
    {
        dead = true;
    }

    protected virtual void RegularMove()
    {
    }

    protected virtual void DeadMove()
    {
        dieVelocity += 0.5f * Physics2D.gravity * dyingGravityMultiplier * Time.deltaTime;
        Vector2 newPosition = transform.position;
        newPosition += dieVelocity * Time.deltaTime;
        transform.position = newPosition;
    }
}
