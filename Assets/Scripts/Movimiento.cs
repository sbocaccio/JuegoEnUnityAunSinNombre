using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimiento : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Defence defence_player;

    [SerializeField]
    private float velocity_punishment = 0.5f;
    public float velocidad = 0.3f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        


        Vector3 characterScale = transform.localScale;

      
        if (movementX < 0)
        {

            animator.SetInteger("Movement_x", 1);

            characterScale.x = -1;
        }
        else if (movementX > 0)
        {

            animator.SetInteger("Movement_x", 1);
            characterScale.x = 1;
        }
        else
        {

            animator.SetInteger("Movement_x", 0);
        }

        transform.localScale = characterScale;
        // Only moves when player is not in defence mode.
        if (!defence_player.defenseActivated())
        {
            transform.Translate(new Vector3(movementX, movementY, 0) * velocidad * Time.deltaTime);

 
        }
        else
        {
            transform.Translate(new Vector3(movementX, movementY, 0)* velocity_punishment * velocidad * Time.deltaTime);

        }
       
    }
}
