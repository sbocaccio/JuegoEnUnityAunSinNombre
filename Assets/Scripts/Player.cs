using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    public Transform attackRangeTransform;

    [SerializeField]
    private float attackRange = 3.0f;

    private int attackDamage = 7;

    public LayerMask enemyLayer;




    void Update()
    {
        base.EntityUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Attack();
            animator.SetTrigger("Kick");
        }
    }

    void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackRangeTransform.position, attackRange, enemyLayer);

        foreach (Collider2D col in colliders)
        {
            Enemy enemy = col.GetComponent<Enemy>();

            enemy.TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackRangeTransform.position, attackRange);
    }


    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(20);
    }
}