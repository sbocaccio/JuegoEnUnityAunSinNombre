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
    private bool attacking = false;
    private int attackDamage = 7;

    public LayerMask enemyLayer;

    public override bool CanLeaveState() { return !attacking| (coolDownTimer <= 0); }
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space) && coolDownTimer == 0)
        {
            if (!imTheCurrentState) stateHandler.StateTriesToChangeChangeState(this);

        }


        coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0)
        {
            if (imTheCurrentState)
            {
                stateHandler.LeavesState(this);
            }
            coolDownTimer = 0;
        }
    }

    public override void IsCurrentState()
    
    {
        Debug.Log("Attacking estado");
        imTheCurrentState = true;
        attack();
        audioManager.Play("Player_Punch1");
        animator.SetTrigger("Punch");
        coolDownTimer = coolDown;
        attacking = true;
    }
    public void AttackTriestoLeaveState()
    {
        Debug.Log("trato de dejar estado");
        stateHandler.LeavesState(this);
    }
    public override void leaveState()
    {
        Debug.Log("dejo attacking");
        if (imTheCurrentState) { 
            imTheCurrentState = false;
            attacking = false;
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
