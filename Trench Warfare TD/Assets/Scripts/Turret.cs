using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
public class Turret : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;

    [Header("References")]
    [SerializeField] private Transform RotationPoint;
    [SerializeField] private LayerMask enemyMask;

    private Transform target;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

    }

    

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
     
        if (hits.Length > 0)
        {
            target = hits[0].transform;

        }
    }
private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        RotationPoint.rotation = targetRotation;
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position,transform.forward, targetingRange);
    }
}