using System.Collections;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StunnerTurret : MonoBehaviour
{



    [Header("Attributes")]
    [SerializeField] private LayerMask enemyMask;

    [SerializeField] private float targetingRange = 20f; // range for detecting enemies
    [SerializeField] private float aps = 4; //attacks per second
    [SerializeField] private float stunTime = 1f; // time to freeze
    private float timeUntilFire;

    void Update()


    {
        timeUntilFire += Time.deltaTime;

        if (timeUntilFire >= 1.5f / aps)
        {
            Stun();
            timeUntilFire = 0f;
        }
    }

    private void Stun() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)
        transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++) {
                RaycastHit2D hit = hits[i];

                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                em.updateSpeed(0.5f);
                StartCoroutine(ResetEnemySpeed(em));

            }
        }
    }
    private IEnumerator ResetEnemySpeed(EnemyMovement em){
        yield return new WaitForSeconds(stunTime);
        
        em.Resetspeed();
        }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}

