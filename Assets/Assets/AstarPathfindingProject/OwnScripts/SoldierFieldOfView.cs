using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFieldOfView : FieldOfView {
    
    bool seeingEnemy;


    public override void TargetInView()
    {
        seeingEnemy = true;
    }
    public override void TargetNotInView()
    {
        seeingEnemy = false;

    }
    public new void Start()
    {
        seeingEnemy = false;
         setParentValues();  
         base.Start();
    
    }
    void setParentValues()
    {
        base.viewAngle = viewAngle;
        base.viewRadius = viewRadius;
        base.visibleTargets = visibleTargets;
        base.targetMask = targetMask;
        base.obstacleMask = obstacleMask;
    }
    public bool SeeingEnemy() {

        return seeingEnemy;
    
    }



}