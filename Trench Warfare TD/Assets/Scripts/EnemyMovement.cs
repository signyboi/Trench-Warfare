using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform turret;
    private float timeUntilFire;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;


    private Transform target;
    private int PathIndex = 0;

    private float baseSpeed;
    private void Start()
    {
        baseSpeed = moveSpeed;
        target = LevelManager.main.path[PathIndex];
    }
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            PathIndex++;

            if (PathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroyed.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[PathIndex];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * moveSpeed;
    }
    public void updateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
    public void Resetspeed()
    {
        moveSpeed = baseSpeed;
    }
}
