using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_animator : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Transform This_transform;
    

    // Flip where the player is looking depending on where is the target.
    public void TurnSide(Vector3 target)
    {
        Vector3 characterScale = This_transform.localScale;
        // The player is on the left
        if ((This_transform.position.x - target.x) >= 0)
        {
            characterScale.x = -1;     
        }
        else {
            characterScale.x = 1;
        }
        This_transform.localScale = characterScale;
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
