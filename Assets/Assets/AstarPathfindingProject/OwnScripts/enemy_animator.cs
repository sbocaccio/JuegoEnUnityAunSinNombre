using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
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
    bool xxx= false;
    bool canRotate = true;
    private void DontRotate()
    {
        canRotate = false;
    }
    private void EnableRotate()
    {
        canRotate = true;
    }
    public void TurnSide(Vector3 target) // Flip where the player is looking depending on where is the target.
    {
        
        if (canRotate)
        {

            Vector3 characterScale = gameObject.transform.localScale;
            // The player is on the left
            if ((gameObject.transform.position.x - target.x) >= 0)
            {
                characterScale.x = -1;
            }
            else
            {
                characterScale.x = 1;
            }
            gameObject.transform.localScale = characterScale;
        }
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

  

    private IEnumerator Wait(float seconds)
    { 
        yield return new WaitForSeconds(seconds);
    }
    
    public bool stillOnAnimation() {
        return xxx;
    }
    public void StartAttacking()
    {
        ReproduceAttackSound();
        animator.SetInteger("State", (int)EnemyStates.Attacking);
        animator.SetInteger("AttackNumber", AttackAnimation);
        ChangeFollowingAttackAnimation();


    }
    
    private void ReproduceAttackSound()
    {
        if (AttackAnimation == 1) audioMananer.Play("Enemy_Punch1");
        else audioMananer.Play("Enemy_Punch2");
    }

    private void ChangeFollowingAttackAnimation()
    {
        // If the enemy has 2 attacks animations, it checks whether AttackAnimation is 1 o -1 to select which one should reproduce.
        AttackAnimation = AttackAnimation * -1;
    }

    void Start()
    {
      
       audioMananer = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
