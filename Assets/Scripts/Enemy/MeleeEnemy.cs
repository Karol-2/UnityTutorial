using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attack Paramenters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;

    [Header("Collider Paramenters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxcollider;

    [Header("Player Layers")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private Health playerHealth;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPatrol>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //attack
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");

            }

        }

        if(enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight(); //if you dont see player keep patroling
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxcollider.bounds.size.x * range,boxcollider.bounds.size.y, boxcollider.bounds.size.z),
            0, Vector2.left,0,playerLayer);

        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxcollider.bounds.size.x * range, boxcollider.bounds.size.y, boxcollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }




}
