using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerFieldOfView : FieldOfView
{
    public override void TargetInView()
    {
        Debug.Log("Enemy in view");
    }
    public override void TargetNotInView()
    {
        Debug.Log("Enemy Not in view");
    }

}