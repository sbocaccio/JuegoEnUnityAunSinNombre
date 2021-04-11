using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    int AttackAnimation = 1; // Values are 1 o -1 depend on which animation should do 
    public static AudioManager audioMananer;


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

    public void StartReadyToAttack()
    {
        animator.SetInteger("State", (int)EnemyStates.ReadyToAttack);
    }

    public void StartAttacking()
    {
        animator.SetInteger("State", (int)EnemyStates.Attacking);
        animator.SetInteger("AttackNumber", AttackAnimation);
       
       
        if (AttackAnimation == 1) audioMananer.Play("Enemy_Punch1");
        else audioMananer.Play("Enemy_Punch2");
        
        //In the next attack, I'll show the other one
        AttackAnimation = AttackAnimation * -1;
       
    }
    

    void Start()
    {
        // animator.SetInteger("State", 2);
       audioMananer = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetInteger("State", 2);

    }
}
