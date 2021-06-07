using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour, IKillable
{
    [SerializeField]
    private bool drops;
    public GameObject thedrop;
    public Transform dropPoint;
    public BarScript lifeBar;
 
    [SerializeField]
    private int max_Health = 100;
    private int current_Health = 100;

    public int GetHealth()
    {
        return current_Health;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void TakeDamage (int damage)
    {
        current_Health = Mathf.Clamp(current_Health - damage, 0, max_Health);
        lifeBar.UnfillBar(damage);
    }
 
    protected void EntityUpdate()
    {
      
        if (GetHealth() <= 0)
        {
           if (drops) { Instantiate(thedrop, dropPoint.position, dropPoint.rotation); }
           Kill();

        }
    }

}
