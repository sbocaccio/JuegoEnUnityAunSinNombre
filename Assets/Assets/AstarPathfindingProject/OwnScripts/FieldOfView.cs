using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour
{



    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public void Start()
    {
        StartCoroutine("FindTargetWithDelay", 0.2f);
    }

    public virtual void TargetInView() { Debug.Log("hola te veo"); }
    public virtual void TargetNotInView() { Debug.Log("hola no te veo"); }
    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    //Finds targets inside field of view not blocked by walls
    void FindVisibleTargets()
    {
        Debug.Log("Dale gato");
        visibleTargets.Clear();
        
        print(viewRadius);
        print(targetMask);
        //Adds targets in view radius to an array
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        print(targetsInViewRadius.Length);
        //For every targetsInViewRadius it checks if they are inside the field of view
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                //If line draw from object to target is not interrupted by wall, add target to list of visible 
                //targets
                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    TargetInView();
                }
                else
                {
                    TargetNotInView();
                }
            }
        }
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}