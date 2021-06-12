using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateHandler : MonoBehaviour
{
    [SerializeField]
    private State actual_state;
    [SerializeField]
    
    void Start()
    {
        actual_state = gameObject.GetComponent<Idle>();
        actual_state.IsCurrentState();
  
    }
    private void Update()
    {
    }
    virtual public void StateTriesToChangeChangeState(State aPetitionerState)
    {
        if (actual_state.CanLeaveState())
        {
            actual_state.leaveState();
            actual_state = aPetitionerState;
            actual_state.IsCurrentState();
        }
    }

    virtual public void LeavesState(State aPetitionerState)
    {
        actual_state.leaveState();
        actual_state = gameObject.GetComponent<Idle>();
    }

}