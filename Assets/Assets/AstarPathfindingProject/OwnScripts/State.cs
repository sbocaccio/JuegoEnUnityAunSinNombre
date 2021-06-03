using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public StateHandler stateHandler;
    protected bool imTheCurrentState;
    // Start is called before the first frame update
    public virtual void IsCurrentState()
    {
        imTheCurrentState = true;
    }
    public virtual void TryToSetState() { }
    public virtual bool CanLeaveState() { return true; }
    

    public virtual void leaveState() {

        imTheCurrentState = false;
    }
    // Update is called once per frame
    void Start()
    {
        stateHandler = gameObject.GetComponent<StateHandler>();


    }
}
