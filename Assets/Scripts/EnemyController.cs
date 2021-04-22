using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool dead;
    public Vector2 dieVelocity;
    public float dyingGravityMultiplier = 5f;
    private SpriteRenderer spriteRenderer;
    public GameObject projectilePrefab;
    protected float timeToShoot = 0f;
    protected bool flipX = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        timeToShoot -= Time.deltaTime;
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
        spriteRenderer.flipY = true;
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

    protected void SetTimeToShoot(float minTime, float maxTime)
    {
        timeToShoot = Random.Range(minTime, maxTime);
    }
}
