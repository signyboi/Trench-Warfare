using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float bulletspeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;


    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

        private void FixedUpdate()
    {
        if (!target) return;
                  
                        Vector2 direction = (target.position - transform.position).normalized;
                rb.linearVelocity = direction * bulletspeed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }

}
