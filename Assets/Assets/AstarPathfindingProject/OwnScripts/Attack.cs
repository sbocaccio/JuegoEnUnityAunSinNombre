using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack : State
{

    [SerializeField]
    private Animator animator;
    public AudioManager audioManager;
    [SerializeField]
    private float coolDown = 1;
    private float coolDownTimer = 0;

    [SerializeField]
    public Transform attackRangeTransform;

    [SerializeField]
    private float attackRange = 3.0f;

    private int attackDamage = 7;

    public LayerMask enemyLayer;
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space) && coolDownTimer == 0)
        {
            attack();
            audioManager.Play("Player_Punch1");
            animator.SetTrigger("Punch");
            coolDownTimer = coolDown;
        }


        coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }
    }

    void attack()
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





}
