using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReach : MonoBehaviour
{

    public Transform attackRangeTransform;
    public Vector2 attackRange;
    public LayerMask target;
    // Start is called before the first frame update
    void Start()
    {
       
    }


    public Collider2D[] TargetsReaching()
    {
       // Physics2D.OverlapBoxAll
       Collider2D[] colliders = Physics2D.OverlapBoxAll(attackRangeTransform.position, attackRange, target);
        return colliders;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(attackRangeTransform.position, attackRange);
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
}
