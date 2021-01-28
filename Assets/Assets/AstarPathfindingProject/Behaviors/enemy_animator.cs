using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyStates
{
    Idle = 0,
    Walking ,
    Running,
    OnGuard,
    ReadyToAttack,
    Attacking,
}

public class enemy_animator : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    

    // Flip where the player is looking depending on where is the target.
    public void TurnSide(Vector3 target)
    {
        Vector3 characterScale = gameObject.transform.localScale;
        // The player is on the left
        if ((gameObject.transform.position.x - target.x) >= 0)
        {
            characterScale.x = -1;     
        }
        else {
            characterScale.x = 1;
        }
        gameObject.transform.localScale = characterScale;
    }

    public void StartRunning()
    {
        animator.SetInteger("State", (int) EnemyStates.Running);

    }
    public void StopRunning()
    {
        animator.SetInteger("State", (int)EnemyStates.Walking);
    }

    public void StartIdle()
    {
        animator.SetInteger("State", (int)EnemyStates.Idle);
        animator.SetBool("Idle", true);
    }
    public void StopIdle()
    {
        animator.SetBool("Idle", false);
    }
    public void StartWalking()
    {
        animator.SetInteger("State", (int)EnemyStates.Walking);

    }
    public void StopWalking()
    {
        animator.SetInteger("State", (int)EnemyStates.Idle);

    }
    public void StartOnGuard()
    {
        animator.SetInteger("State", (int)EnemyStates.OnGuard);

    }
    public void StopOnGuard()
    {
        animator.SetInteger("State", (int)EnemyStates.Running);

    }

    void Start()
    {
       // animator.SetInteger("State", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetInteger("State", 2);

    }
}
