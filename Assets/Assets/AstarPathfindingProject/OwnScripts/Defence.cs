using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : State
{


    [SerializeField]
    private GameObject playerObject;
    bool DefenseMode = false;
  
  
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override bool CanLeaveState() { return true; }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if(!imTheCurrentState) stateHandler.StateTriesToChangeChangeState(this);

        }
        if (Input.GetKeyUp(KeyCode.X))
        {

            if(imTheCurrentState) stateHandler.LeavesState(this);
        }
    }
    public override void IsCurrentState()
    {
        imTheCurrentState = true;
        ActivateDefense();
    }

    public override void leaveState()
    {

        imTheCurrentState = false;
        DesActivateDefense();
    }
    void ActivateDefense()
    {
        animator.SetTrigger("Defence_activated");
        DefenseMode = true;
        animator.ResetTrigger("Defence_desactivated");
    }

    void DesActivateDefense()
    {
        animator.ResetTrigger("Defence_activated");
        animator.SetTrigger("Defence_desactivated");
        DefenseMode = false;
    }
    public bool defenseActivated(){
        return DefenseMode;
    }
 

}
