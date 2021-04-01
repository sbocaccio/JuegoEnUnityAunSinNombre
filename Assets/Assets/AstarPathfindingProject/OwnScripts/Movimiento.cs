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
    bool lastMovementWasLeft;

    public int characterSpriteSize()
    {
        // Player looks right is positive, left is negative
        if (transform.localScale.x > 0) return 1;
        else return -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 ChangeScaleSize(float movementX, float movementY, Vector3 characterScale)
    {
        if (movementX < 0)
        {
            if (!lastMovementWasLeft)
            {
                animator.SetInteger("Movement_x", 1);
                characterScale.x = -characterScale.x;
            }
            Debug.Log("Izquierda");
            lastMovementWasLeft = true;
        }
        else if (movementX > 0)
        {
            if (lastMovementWasLeft)
            {
                animator.SetInteger("Movement_x", 1);
                characterScale.x = -characterScale.x;
            }
            lastMovementWasLeft = false;
        }
        else
        {
            animator.SetInteger("Movement_x", 0);
        }
        return characterScale;
    }

void move(float movementX,float  movementY) {

        if (!defence_player.defenseActivated())
        {
            transform.Translate(new Vector3(movementX, movementY, 0) * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(movementX, movementY, 0) * velocity_punishment * velocidad * Time.deltaTime);
            defence_player.updateDefenceSize();
        }
}

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

   
        Vector3 characterScale = transform.localScale;
        transform.localScale = ChangeScaleSize( movementX, movementY, characterScale);
        move(movementX,movementY);
    }


    
    
}
