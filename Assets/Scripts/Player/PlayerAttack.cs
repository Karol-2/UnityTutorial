using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject[] Fireballs;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    

private void Awake()
{
    anim = GetComponent<Animator>();
    playerMovement = GetComponent<PlayerMovement>();
}

private void Update()
{
    if(Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        Attack();
        
    cooldownTimer += Time.deltaTime;
}
private void Attack()
{
    anim.SetTrigger("attack");
    cooldownTimer = 0;

    Fireballs[FindFireball()].transform.position = FirePoint.position;
    Fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
}
private int FindFireball()
{
    for(int i=0 ; i<Fireballs.Length;i++)
    {
        if(!Fireballs[i].activeInHierarchy)
            return i;
    }

    return 0;

}
}