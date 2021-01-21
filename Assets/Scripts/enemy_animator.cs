using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyStates
{
    Idle = 0,
    Walking ,
    Running,
}

public class enemy_animator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private Transform enemy_transform;

    public enemy_animator( Animator anim, Transform enemy_trans)
    {
        animator = anim;
        enemy_transform = enemy_trans;
    }

    // Flip where the player is looking depending on where is the target.
    public void TurnSide(Vector3 target)
    {
        Vector3 characterScale = enemy_transform.localScale;
        // The player is on the left
        if ((enemy_transform.position.x - target.x) >= 0)
        {
            characterScale.x = -1;     
        }
        else {
            characterScale.x = 1;
        }
        enemy_transform.localScale = characterScale;
    }

    public void StartRunning()
    {
        animator.SetInteger("State", (int) EnemyStates.Running);

    }
    public void StopRunning()
    {
        animator.SetInteger("State", (int)EnemyStates.Idle);
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
