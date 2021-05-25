
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimiento : State
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Defence defence_player;

    [SerializeField]
    private float velocity_punishment = 0.5f;
    public float velocidad = 0.3f;
    bool lastMovementWasLeft =false ;
    bool notMoving = true;


    /*Roll*/
    private bool rolling = false;
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    private float rollSide;

    public override bool CanLeaveState() { return !rolling; }

    public bool playerIsLookingRight()
    {
        return transform.localScale.x > 0;
    }
    public bool playerIsLookingLeft()
    {
        return !(transform.localScale.x > 0);

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    private Vector3 correctSide(float movementX, Vector3 characterScale)
    {
        if ( (lastMovementWasLeft && (movementX > 0)) || ( !lastMovementWasLeft && (movementX < 0))) {
            characterScale.x = -characterScale.x;
        }

        if (movementX > 0) lastMovementWasLeft = false;
        else if (movementX < 0) lastMovementWasLeft = true;

        
        return characterScale;
    }

    void  setCorrectAnimation(float movementX, float movementY)
    {
        if (movementX != 0 || movementY != 0 )
        {
            notMoving = false;
            animator.SetInteger("Running", 1);
        }
        else
        { 
            notMoving = true;
            animator.SetInteger("Running", 0);
        }
    }

    void move(float movementX, float movementY)
    {
        if (!defence_player.defenseActivated())
        {
            transform.Translate(new Vector3(movementX, movementY, 0) * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(movementX, movementY, 0) * velocity_punishment * velocidad * Time.deltaTime);
        }
    }

    private void checkRolling()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartRolling();
        }

    }
    private void DoMovement(float movementX,float movementY)
    {
        checkRolling();
        if (!rolling)
        {
            setCorrectAnimation(movementX, movementY);
            Vector3 characterScale = transform.localScale;
            transform.localScale = correctSide(movementX, characterScale);
            move(movementX, movementY);
        }
        else
        {
            
            move(rollSide, movementY);
            dashTime -= Time.deltaTime;
            if (dashTime <= 0) { rolling = false; }
        }

    }
    private void StartRolling()
    {
        if (!rolling)
        {
            dashTime = startDashTime;
            rolling = true;
            animator.SetTrigger("Roll");

            if (playerIsLookingLeft())
            {
                rollSide = -1;
            }
            else if (playerIsLookingRight())
            {
                rollSide = 1;
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        DoMovement(movementX, movementY);
       
    }




}